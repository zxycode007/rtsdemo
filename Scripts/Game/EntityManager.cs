using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EntityManager : BaseObject
{
    public Transform curEntity;
    public List<EntityView> m_entities;

    public static EntityManager instance;

    void Awake()
    {
        instance = this;
        
    }

    void RegisterEvt()
    {
        GameEventManager.instance.AddEventReceiver(GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, evtCtx, OnHandleInput);
       
    }

    void OnHandleInput(object sender, EventArgs arg)
    {
        GameEvtArg garg = arg as GameEvtArg;
        if(garg != null && garg.m_buf != null)
        {
            int i = garg.m_buf.ReadByte();
            EntityAnimator animator = curEntity.gameObject.GetComponent<EntityAnimator>();
            if (animator == null)
                return;
            switch(i)
            {
                case 0:
                    {
                        animator.Play(EAnimationType.LPunch, 1);
                    }
                    break;
                case 1:
                    {
                        animator.Play(EAnimationType.RPunch, 1);
                    }
                    break;
                case 2:
                    {
                        animator.Play(EAnimationType.LPunchMove, 1);
                    }
                    break;
                case 3:
                    {
                        animator.Play(EAnimationType.RPunchMove, 1);
                    }
                    break;
                case 4:
                    {
                        animator.Play(EAnimationType.LKick, 1);
                    }
                    break;
                case 5:
                    {
                        animator.Play(EAnimationType.RKick, 1);
                    }
                    break;
            }
        }
    }

    void UnRegisterEvt()
    {
        GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, evtCtx, OnHandleInput);
    }

    // Use this for initialization
    void Start()
    {
        RegisterEvt();
    }

   //逻辑更新
    public void LogicUpdate()
    {
        foreach(EntityView ev in m_entities)
        {
            ev.UpdateFSM();
        }
    }
}
