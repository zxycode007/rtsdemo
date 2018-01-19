using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class EntityAnimationState : LogicEntityState
{
   
    EntityAnimator m_animator;
    //动画名
    string m_animation;
    //动画速度
    float m_animationSpeed;
    //动画类型
    EAnimationType m_animType;
    //循环次数,  次数1：不循环  -1 无限
    int m_loopCount;


    public string animantioName
    {
        get
        {
            return m_animation;
        }
        set
        {
            m_animation = value;
        }
    }

    public float animationSpeed
    {
        get
        {
            return m_animationSpeed;
        }
        set
        {
            m_animationSpeed = value;
        }
    }

    public int loopCount
    {
        get
        {
            return m_loopCount; ;
        }
        set
        {
            m_loopCount = value;
        }
    }
    

    public EntityAnimationState():base()
    {
        m_type = EStateType.EStateType_EntityAnimation;
        m_animationSpeed = 1.0f;
         
    }

    public override void OnCommand(EActionType action, byte[] param)
    {
        
    }
    

    public override void OnEnterState()
    {
         
        base.OnEnterState();
        object obj = Enum.Parse(typeof(EAnimationType), m_animation);
        if(obj != null)
        {
            m_animType = (EAnimationType)obj;
        }else
        {
            m_animType = EAnimationType.Stand;
        }
    }

    public override void OnStartState()
    {
        base.OnStartState();
        if (entityview == null)
        {
            Goto(timeOutState);
        }
        m_animator = entityview.animator;
        if (m_animator != null)
        {
            m_animator.Play(m_animType, m_animationSpeed);
        }
    }

    public override void OnUpdateState()
    {
        base.OnUpdateState();
        //
        if(m_entityView == null)
        {
            Goto(timeOutState);
        }

    }

    public override void OnEndState()
    {
        base.OnEndState();
        //if (m_animator != null)
        //{
        //    m_animator.Play(EAnimationType.Stand, 1.0f);
        //}
    }

    public override void OnLeaveState()
    {
        base.OnLeaveState();
    }

    public override BaseState Clone()
    {
        EntityAnimationState cloneObj = new EntityAnimationState();
        cloneObj.durationTick = this.durationTick;
        cloneObj.name = this.name;
        cloneObj.animantioName = this.animantioName;
        cloneObj.animationSpeed = this.animationSpeed;
        cloneObj.loopCount = this.loopCount;
        foreach (KeyValuePair<int, StateLink> kv in m_links)
        {
            StateLink link = new StateLink();
            link.linkID = kv.Value.linkID;
            link.linkStateName = kv.Value.linkStateName;
            cloneObj.m_links[link.linkID] = link;
        }
        return cloneObj;
    }
    
}
