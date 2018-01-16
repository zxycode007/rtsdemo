using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EStateType
{
    EStateType_EntityAnimation,
    EStateType_LoginEntiy,
    EStateType_Default
}

public struct StateLink
{
    public int linkID;
    public string linkStateName;

}

public class BaseState
{

    protected EStateType m_type;
    //当前状态比例
    protected float m_percent;
    //状态的实体
    protected EntityView m_entityView;
    protected string m_name;

    

    //已流逝tick
    protected long m_elapseTick;
    protected long m_curTick;
    protected long m_startTick;
    //持续时间
    protected long m_durationTick;

    Dictionary<int, StateLink> m_links;

    public long elapseTick
    {
        get
        {
            return m_elapseTick;
        }
    }

    public long durationTick
    {
        get
        {
            return m_durationTick;
        }
        set
        {
            m_durationTick = value;
        }
    }

    public string name
    {
        get
        {
            return m_name;
        }
        set
        {
            m_name = value;
        }
    }
 
    public Dictionary<int, StateLink> links
    {
        get
        {
            return m_links;
        }
    }

    public BaseState timeOutState;
    protected BaseFSM m_curFsm;



    public BaseFSM curFSM
    {
        get
        {
            return m_curFsm;
        }
        set
        {
            m_curFsm = value;
        }
    }
    public EntityView entityview
    {
        get
        {
            return m_entityView;
        }
        set
        {
            m_entityView = value;
        }
    }

    public int GetUID()
    {
        if (m_entityView)
            return m_entityView.uid;
        return 0;
    }

    public virtual void OnEnterState()
    {
        m_curFsm.currentState = this;
        m_startTick = TimeManager.instance.GetCurTick();
        m_elapseTick = 0;   
    }

    public virtual void OnStartState()
    {
         
         
    }

    /// <summary>
    /// 跳转去其它状态
    /// </summary>
    /// <param name="outstate"></param>
    protected void Goto(BaseState outstate)
    {    
        OnLeaveState();
        outstate.OnEnterState();
    }

    public virtual void OnUpdateState()
    {
         m_curTick = TimeManager.instance.GetCurTick();
         m_elapseTick = m_curTick - m_startTick;
        if(m_elapseTick > m_durationTick)
            {
                percent = 1.0f;

            }else
            {
                percent = (float)(m_elapseTick) / (float)(m_durationTick);
                
            }

            if(percent >= 1.0f)
            {
                OnEndState();
                Goto(timeOutState);
            }
    }

    

    public virtual void OnEndState()
    {

    }

    public virtual void OnLeaveState()
    {

    }

    public float percent
    {
        get
        {
            return m_percent;
        }
        set
        {
            m_percent = value;
            m_percent =  Mathf.Clamp(m_percent, 0.0f, 1.0f);
        }
    }

   // public void OnCommand()

    public BaseState()
    {
        m_type = EStateType.EStateType_Default;
        percent = 0;
        //默认循环
        timeOutState = this;
        m_curFsm = null;
        m_links = new Dictionary<int,StateLink>();
    }

    
    
}
