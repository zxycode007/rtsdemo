using UnityEngine;
using System.Collections;

public enum EStateType
{
    EStateType_Move,
    EStateType_Attack,
    EStateType_Stand,
    EStateType_None
}

public class BaseState
{

    protected EStateType m_type;
    //当前状态比例
    protected float m_percent;
    //状态的实体
    protected EntityView m_entityView;


    //已流逝tick
    protected long m_elapseTick;
    protected long m_curTick;
    protected long m_startTick;
    protected long m_durationTick;

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

    public BaseState()
    {
        m_type = EStateType.EStateType_None;
        percent = 0;
        //默认循环
        timeOutState = this;
        m_curFsm = null;
    }

   
}
