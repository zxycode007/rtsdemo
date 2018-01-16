using UnityEngine;
using System.Collections;

/// <summary>
/// 移动命令
/// 进入移动状态,长期状态
/// </summary>
public class MoveAction : BaseAction
{
    private Vector3 startPos;
    public  Vector3 endPos;

    public MoveAction()
    {
        mType = EActionType.EAction_Move;
        m_bRunning = false;
        m_bFinished = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (m_entiyView == null)
        {
            m_bFinished = true;
        }
        startPos = m_entiyView.position;
        LogicEntityFSM fsm = m_entiyView.GetFSM("LogicEntityFSM") as LogicEntityFSM;
        if(fsm != null)
        {
           fsm.OnCommand(EActionType.EAction_Move, null);
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        run();
    }

    public override void OnLeave()
    {
        base.OnLeave();
        LogicEntityFSM fsm = m_entiyView.GetFSM("LogicEntityFSM") as LogicEntityFSM;
        if (fsm != null)
        {
            fsm.OnCommand(EActionType.EAction_Idle, null);
        }
    }

    public override void run()
    {
        if (m_entiyView == null)
            m_bFinished = true;
        Vector3 curPos = startPos + (endPos - startPos) * m_percent;
        m_entiyView.position = curPos;
        return;
        
    }
}
