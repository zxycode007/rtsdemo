using UnityEngine;
using System.Collections;

//暂时定义的命令类型
public enum EActionType
{
    EAction_MoveTo,
    EAction_Move,
    EAction_StopMove,
    EAction_Idle,
    EAction_Attack,
    EAction_None
}

public enum ECommandPriority
{
    EAction_High,  //高的话，不用等之前命令执行完，冲掉当前命令，执行这个命令
    EAction_Low    //低的话，压入队列，等待前一个执行完毕，再执行这个
}

public class BaseAction
{
    protected GameEventContext m_EvtCtx = new GameEventContext();
    protected EActionType mType;
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
    public ActionManager actionMgr;
    

    public BaseAction()
    {
        mType = EActionType.EAction_None;
        m_bFinished = false;
        m_bRunning = false;
        m_entiyView = null;
        priority = ECommandPriority.EAction_Low;
         
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
    
    public virtual void run()
    {

    }

    public virtual void OnEnter()
    { }

    public virtual void OnLeave()
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

    public EActionType commandType
    {
        get
        {
            return mType;
        }
    }

    //按开始时间排序
    public static bool Compare(HeapNode<BaseAction> A, HeapNode<BaseAction> B)
    {
        return A.Value.startTick > B.Value.startTick;
    }

    
}
