using System;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DCL.Huds
{
    public class VRHUDController : MonoBehaviour
    {
        public static Action LoadingStart;
        public static Action LoadingEnd;
        public static VRHUDController I { get; private set; }
        private HUDController controller => HUDController.i;
        private readonly Vector3 hidenPos = new Vector3(0, -10, 0);
        private readonly List<VRHUDHelper> huds = new List<VRHUDHelper>();
        private readonly List<VRHUDHelper> submenu = new List<VRHUDHelper>();

        private DCLPlayerInput playerInput;
        BaseVariable<bool> exploreV2IsOpen => DataStore.i.exploreV2.isOpen;
        
        [SerializeField]
        private GameObject visuals;
        [SerializeField]
        private Transform dock;
        [SerializeField]
        private Canvas dockCanvas;
        private Transform mainCam;
        private DCLPlayerInput.PlayerActions actions;
        private bool loading;


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
            LoadingStart += OnLoadingStart;
            LoadingEnd += OnLoadingEnd;
            dockCanvas.overrideSorting = true;
        }

        private void Start()
        {
            actions = InputController.GetPlayerActions();
            if (!actions.enabled) actions.Enable();
            actions.OpenMenu.performed += OpenHandMenu;
            dock.position = hidenPos;
            exploreV2IsOpen.OnChange += HideSubs;
        }

        private void OpenHandMenu(InputAction.CallbackContext context)
        {
            if (loading) return;
            visuals.SetActive(!visuals.activeSelf);
            DeactivateHud();
        }

        private void HideSubs(bool current, bool previous)
        {
            for (int i = 0; i < submenu.Count; i++)
            {
                VRHUDHelper menu = submenu[i];
                if (current) menu.Hide(hidenPos);
                else menu.ResetHud();
            }
        }

        private void OnLoadingEnd()
        {
            loading = false;
        }
        private void OnLoadingStart()
        {
            loading = true;
            visuals.SetActive(false);
        }

        public static void RaiseLoadingStart()
        {
            LoadingStart?.Invoke();
        }

        public static void RaiseLoadingEnd()
        {
            LoadingEnd?.Invoke();
        }

        public void Register(VRHUDHelper helper, bool isSubmenu)
        {
            huds.Add(helper);
            if (isSubmenu) submenu.Add(helper);
        }

        public void Reparent(Transform helperTrans)
        {
            helperTrans.parent = dock;
            helperTrans.localPosition = Vector3.zero;
            helperTrans.localRotation = Quaternion.identity;
            helperTrans.localScale = Vector3.one;
            switch (helperTrans)
            {
                case RectTransform rectTransform:
                    rectTransform.sizeDelta = new Vector2(1920, 1080);
                    break;
            }
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
