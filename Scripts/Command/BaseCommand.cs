using UnityEngine;
using System.Collections;

//暂时定义的命令类型
public enum ECommandType
{
    ECommand_Move,
    ECommand_Idle,
    ECommand_Attack,
    ECommand_None
}

public enum ECommandPriority
{
    ECommand_High,  //高的话，不用等之前命令执行完，冲掉当前命令，执行这个命令
    ECommand_Low    //低的话，压入队列，等待前一个执行完毕，再执行这个
}

public class BaseCommand
{
    protected GameEventContext m_EvtCtx = new GameEventContext();
    protected ECommandType mType;
    protected bool m_bFinished;
    protected bool m_bRunning;
    //命令对象
    protected EntityView  m_entiyView;
    //命令的产生的时间
    public long sendTick;
    //命令的执行时刻
    public long startTick;
    //命令结束时刻
    public long endTick;
    public ECommandPriority priority;
    

    public BaseCommand()
    {
        mType = ECommandType.ECommand_None;
        m_bFinished = false;
        m_bRunning = false;
        m_entiyView = null;
        priority = ECommandPriority.ECommand_Low;
         
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

    //按开始时间排序
    public static bool Compare(HeapNode<BaseCommand> A, HeapNode<BaseCommand> B)
    {
        return A.Value.startTick > B.Value.startTick;
    }

    
}
