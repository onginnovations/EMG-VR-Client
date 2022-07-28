using System;
using UnityEngine;

public class PopupHudHelper : VRHUDHelper
{
    [SerializeField]
    protected GameObject objectToHide;
    
    protected override void SetupHelper()
    {
        if (!objectToHide)
            objectToHide = gameObject;
        myTrans.localScale = 0.0025f * Vector3.one;
        objectToHide.SetActive(false);
        if (showHideAnimator)
            showHideAnimator.OnStartShow += PositionHud;
    }

    private void OnEnable()
    {
        if (showHideAnimator) return;
        PositionHud();
    }

    private void PositionHud()
    {
        CrossPlatformManager.GetSurfacePoint(out var point, out var normal);
        myTrans.position = point + normal * .25f;
        myTrans.forward = -normal;
    }
}
