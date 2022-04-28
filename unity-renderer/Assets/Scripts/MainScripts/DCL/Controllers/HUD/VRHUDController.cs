using System;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

namespace DCL.Huds
{
    public class VRHUDController : MonoBehaviour
    {
        public static Action LoadingStart;
        public static Action LoadingEnd;
        public static VRHUDController I { get; private set; }
        private HUDController controller => HUDController.i;
        private readonly Vector3 hidenPos = new Vector3(0, 300, 0);
        private readonly List<VRHUDHelper> huds = new List<VRHUDHelper>();
        BaseVariable<bool> exploreV2IsOpen => DataStore.i.exploreV2.isOpen;
        
        [SerializeField]
        private GameObject visuals;
        [SerializeField]
        private Transform dock;
        [SerializeField]
        private Canvas dockCanvas;
        private Transform mainCam;

        private void Awake()
        {
            if (I != null)
            {
                Destroy(this);
                return;
            }
            I = this;
            if (Camera.main != null)
                mainCam = Camera.main.transform;
            LoadingStart += HideVisuals;
            LoadingEnd += ShowVisuals;
            dockCanvas.overrideSorting = true;
        }

        private void Start()
        {
            dock.position = hidenPos;
        }

        private void ShowVisuals() => visuals.SetActive(true);
        private void HideVisuals() => visuals.SetActive(false);

        public static void RaiseLoadingStart()
        {
            LoadingStart?.Invoke();
        }

        public static void RaiseLoadingEnd()
        {
            LoadingEnd?.Invoke();
        }

        public void Register(VRHUDHelper helper)
        {
            huds.Add(helper);
        }

        public void Reparent(Transform helperTrans)
        {
            helperTrans.parent = dock;
            helperTrans.localPosition = Vector3.zero;
            helperTrans.localRotation = Quaternion.identity;
            helperTrans.localScale = Vector3.one;
        }

        public void MoveHud()
        {
            Vector3 forward = GetForward();
            if (Vector3.Distance(dock.position, mainCam.position) > 2f) PositionHud(forward);
            else DeactivateHud();
        }
        
        public Vector3 GetForward()
        {
            var rawForward = mainCam.forward;
            var forward = new Vector3(rawForward.x, 0f , rawForward.z).normalized;
            return forward;
        }

        private void PositionHud(Vector3 forward)
        {
            for (int i = 0; i < huds.Count; i++)
            {
                huds[i].ResetHud();
            }
            dock.position = mainCam.position + forward;
            dock.forward = forward;
        }
        
        public void DeactivateHud()
        {
            if (exploreV2IsOpen.Get()) exploreV2IsOpen.Set(false);
            for (int i = 0; i < huds.Count; i++)
            {
                dock.position = hidenPos;
            }
        }
    }
}
