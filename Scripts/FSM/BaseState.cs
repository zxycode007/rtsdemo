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
    public bool isRunning;
    //开始tick
    public long startTick;
    //结束tick
    public long endTick;

    public BaseState timeOutState;
    protected BaseFSM m_curFsm;

    long m_curTick;


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
        
    }

    public virtual void OnStartState()
    {
        if (startTick > endTick)
            startTick = endTick;
         
    }

    protected void Goto(BaseState outstate)
    {
        m_curFsm.m_curState = outstate;
        OnLeaveState();
        outstate.OnEnterState();
    }

    public virtual void OnUpdateState()
    {
        if(isRunning)
        {
            m_curTick = TimeManager.instance.GetCurTick();
            if(m_curTick > endTick)
            {
                percent = 1.0f;

            }else
            {
                percent = (float)(m_curTick - startTick) / (float)(endTick - startTick);
            }

            if(percent >= 1.0f)
            {
                OnEndState();
                Goto(timeOutState);
            }
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
        isRunning = false;
        //默认循环
        timeOutState = this;
        m_curFsm = null;
    }

   
}
