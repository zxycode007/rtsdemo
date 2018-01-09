using UnityEngine;
using System.Collections;

public class FreedomCameraMode : CameraMode
{

     public FreedomCameraMode()
    {
        m_type = ECameraModeType.FreedomCamera;

    }

     public override void Init()
     {
         base.Init();
     }

     public override void Update()
     {
         base.Update();
     }

     public override void OnSwitchMode()
     {
         base.OnSwitchMode();
     }

     public override void RegisterEvt()
     {
         base.RegisterEvt();
     }

     public override void UnRegisterEvt()
     {
         base.UnRegisterEvt();
     }
}
