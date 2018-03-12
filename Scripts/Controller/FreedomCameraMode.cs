using UnityEngine;
using System.Collections;
using System;

public class FreedomCameraMode : CameraMode
{
    public float m_xSpeed;
    public float m_ySpeed;
    public float m_minVerticalAngle;
    public float m_maxVerticalAngle;
    public float m_MoveSpeed;

    private bool isLMBDown;
    private bool isRMBDown;
    private bool isFwdBtnDown;
    private bool isBkBtnDown;
    private bool isTlBtnDown;
    private bool isTrBtnDown;

    private float x;
    private float y;

     public FreedomCameraMode()
    {
        m_type = ECameraModeType.FreedomCamera;
        m_xSpeed = 300;
        m_ySpeed = 300;
        m_MoveSpeed = 20;
        m_minVerticalAngle = -90;
        m_maxVerticalAngle = 90;

    }


     public void OnMouseButtonDown(object sender, EventArgs arg)
     {
         GameEvtArg garg = arg as GameEvtArg;
         if (garg != null && garg.m_buf != null)
         {
             int i = garg.m_buf.ReadByte();
             if (i == 0)
             {
                 isRMBDown = true;
             }
             else if (i == 1)
             {
                 isLMBDown = true;
             }
         }

     }

     public void OnMouseButtonUp(object sender, EventArgs arg)
     {
         GameEvtArg garg = arg as GameEvtArg;
         if (garg != null && garg.m_buf != null)
         {
             int i = garg.m_buf.ReadByte();
             if (i == 0)
             {
                 isRMBDown = false;

             }
             else if (i == 1)
             {
                 isLMBDown = false;
             }
         }
     }

     public void OnMouseMove(object sender, EventArgs arg)
     {
         GameEvtArg garg = arg as GameEvtArg;
         if (garg != null && garg.m_buf != null)
         {
             float deltaX = garg.m_buf.ReadFloat();
             float deltaY = garg.m_buf.ReadFloat();
             if (isRMBDown)
             {
                 x += deltaX * m_xSpeed * 0.02f;
                 y -= deltaY * m_ySpeed * 0.02f;
                 y = MathHelper.ClampAngle(y, m_minVerticalAngle, m_maxVerticalAngle);

                 //根据顺序绕Z,X,Y旋转角度生成一个四元数
                 Quaternion rot = Quaternion.Euler(new Vector3(y, x, 0));
                 transform.rotation = rot;
             }
         }
     }

    public void  OnKeyDown(object sender, EventArgs arg)
     {
         GameEvtArg garg = arg as GameEvtArg;
         if (garg != null && garg.m_buf != null)
         {
             KeyCode code = (KeyCode) garg.m_buf.ReadInt();
             if(code == KeyCode.W)
             {
                 isFwdBtnDown = true;
             }
             if (code == KeyCode.S)
             {
                 isBkBtnDown = true;
             }
             if (code == KeyCode.A)
             {
                 isTlBtnDown = true;
             }
             if (code == KeyCode.D)
             {
                 isTrBtnDown = true;
             }
         }

     }

    public void OnKeyUp(object sender, EventArgs arg)
    {
        GameEvtArg garg = arg as GameEvtArg;
        if (garg != null && garg.m_buf != null)
        {
            KeyCode code = (KeyCode)garg.m_buf.ReadInt();
            if (code == KeyCode.W)
            {
                isFwdBtnDown = false;
            }
            if (code == KeyCode.S)
            {
                isBkBtnDown = false;
            }
            if (code == KeyCode.A)
            {
                isTlBtnDown = false;
                
            }
            if (code == KeyCode.D)
            {
                isTrBtnDown = false;
            }
        }

    }


     public override void Init()
     {
         base.Init();
         isLMBDown = false;
         isRMBDown = false;
         isBkBtnDown = false;
         isFwdBtnDown = false;
         isTlBtnDown = false;
         isTrBtnDown = false;
         RegisterEvt();
     }

     public override void Update()
     {
         if(isFwdBtnDown)
         {
             transform.position = transform.position + transform.forward * m_MoveSpeed * 0.01f;
         }
         if(isBkBtnDown)
         {
             transform.position = transform.position - transform.forward * m_MoveSpeed * 0.01f;
         }
         if(isTlBtnDown)
         {
             transform.position = transform.position - transform.right * m_MoveSpeed * 0.01f;
         }
         if(isTrBtnDown)
         {
             transform.position = transform.position + transform.right * m_MoveSpeed * 0.01f;
         }
         
         base.Update();
     }

     public override void OnSwitchMode()
     {
         base.OnSwitchMode();
     }

     public override void RegisterEvt()
     {
         GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN, m_EvtCtx, OnMouseButtonDown);
         GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_UP, m_EvtCtx, OnMouseButtonUp);
         GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_MOUSE_MOVE, m_EvtCtx, OnMouseMove);
         GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_KEYBOARD_KEY_DOWN, m_EvtCtx, OnKeyDown);
         GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_KEYBOARD_KEY_UP, m_EvtCtx, OnKeyUp);
     }

     public override void UnRegisterEvt()
     {
         GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN, m_EvtCtx, OnMouseButtonDown);
         GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_UP, m_EvtCtx, OnMouseButtonUp);
         GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_MOUSE_MOVE, m_EvtCtx, OnMouseMove);
         GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_KEYBOARD_KEY_DOWN, m_EvtCtx, OnKeyDown);
         GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_KEYBOARD_KEY_UP, m_EvtCtx, OnKeyUp);
     }
}
