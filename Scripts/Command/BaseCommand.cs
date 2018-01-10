using UnityEngine;
using System.Collections;

public enum ECommandType
{
    ECommand_Move,
    ECommand_Idle,
    ECommand_Attack,
    ECommand_None
}

public class BaseCommand
{
    protected GameEventContext m_EvtCtx = new GameEventContext();
    protected ECommandType mType;
    protected bool m_bFinished;
    protected bool m_bRunning;
    protected EntityView  m_entiyView;
    //命令的产生的时间
    public long sendTick;
    //命令的执行时刻
    public long startTick;
    public long endTick;
    

    public BaseCommand()
    {
        mType = ECommandType.ECommand_None;
        m_bFinished = false;
        m_bRunning = false;
        m_entiyView = null;
         
    }

    public int GetUID()
    {
        if(m_entiyView != null)
        {
            return m_entiyView.uid;
        }
        return 0;
    }

    public EntityView entity
    {
        get
        {
            return m_entiyView;
        }
        set
        {
            m_entiyView = value;
        }
    }
    
    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
    public virtual void OnUpdate()
    {

    }

    public bool isRunning()
    {
        return m_bRunning;
    }

    public bool isFinished()
    {
        return m_bFinished;
    }

    public ECommandType commandType
    {
        get
        {
            return mType;
        }
    }
    



    
}
