using UnityEngine;
using System.Collections;
using System;

public class ThirdPersonCameraMode : CameraMode
{

    public Transform m_target;
    public float m_xSpeed;
    public float m_ySpeed;
    public float m_targetDistance;
    public float m_targetHeight;
    public float m_minVerticlAngle;
    public float m_maxVerticlAngle;
    
    private bool isLMBDown;
    private bool isRMBDown;

    private float x;
    private float y;
    RaycastHit hit;

    public ThirdPersonCameraMode()
    {
        m_type = ECameraModeType.ThirdPersonCamera;
        m_xSpeed = 300;
        m_ySpeed = 300;
        m_targetDistance = 4;
        m_targetHeight = 1;
        m_minVerticlAngle = -90;
        m_maxVerticlAngle = 90;
       
    }

    void FindCurTarget()
    {
        m_target = EntityManager.instance.curEntity;
    }

    public override void Init()
    {

        FindCurTarget();
        if (m_target == null)
            return;
        transform.LookAt(m_target.transform);
        Vector3 dir = transform.position - m_target.position;
        dir.Normalize();
        transform.position = m_target.position + dir * m_targetDistance;
        transform.position = new Vector3(transform.position.x, m_target.transform.position.y + m_targetHeight, transform.position.x);
        isLMBDown = false;
        isRMBDown = false;
        RegisterEvt();
    }


    public override void RegisterEvt()
    {
        GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN, m_EvtCtx, OnMouseButtonDown);
        GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_UP, m_EvtCtx, OnMouseButtonUp);
        GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_MOUSE_MOVE, m_EvtCtx, OnMouseMove);

    }

    public override void UnRegisterEvt()
    {
        GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN, m_EvtCtx, OnMouseButtonDown);
        GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_MOUSE_BUTTON_UP, m_EvtCtx, OnMouseButtonUp);
        GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_MOUSE_MOVE, m_EvtCtx, OnMouseMove);
    }

    public void OnMouseButtonDown(object sender, EventArgs arg)
    {
        GameEvtArg garg = arg as GameEvtArg;
        if (garg != null && garg.m_buf != null)
        {
            int i = garg.m_buf.ReadByte();
            if(i == 0)
            {
                isRMBDown = true;
            }else if(i == 1)
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
             if(isRMBDown)
             {
                 x += deltaX * m_xSpeed * 0.02f;
                 y -= deltaY * m_ySpeed * 0.02f;
                 y = MathHelper.ClampAngle(y, m_minVerticlAngle, m_maxVerticlAngle);

                 //根据顺序绕Z,X,Y旋转角度生成一个四元数
                 Quaternion rot = Quaternion.Euler(new Vector3(y, x, 0));
                 transform.rotation = rot;
             }
         }
    }
    

    public override void Update()
    {
        if(m_target == null)
        {
            return;
        }
        //设置相机于观察目标的位置
        Vector3 position = m_target.position - (transform.rotation * Vector3.forward * m_targetDistance + new Vector3(0.0f, -m_targetHeight, 0.0f));
        transform.position = position;

        m_target.transform.rotation = Quaternion.Euler(0, x, 0);
    }

    

    public override void OnSwitchMode()
    {
        UnRegisterEvt();
    }
     
}
