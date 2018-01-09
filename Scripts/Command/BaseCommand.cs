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

    public BaseCommand()
    {
        mType = ECommandType.ECommand_None;
        m_bFinished = false;
        m_bRunning = false;
        m_entiyView = null;
         
    }
    public BaseCommand(EntityView ev)
    {
        mType = ECommandType.ECommand_None;
        m_bFinished = false;
        m_bRunning = false;
        m_entiyView = ev;
    }
    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }
    public virtual void update()
    {

    }

    public 

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
