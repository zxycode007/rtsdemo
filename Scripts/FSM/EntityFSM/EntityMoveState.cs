using UnityEngine;
using System.Collections;



/// <summary>
/// 移动状态
/// 从一个目标点移动到另一个目标点，结束后切换回Stand状态
/// 
/// </summary>
public class EntityMoveState : BaseState
{
    public Vector3 startPos;
    public Vector3 endPos;
    EntityAnimator m_animator;

    public EntityMoveState():base()
    {
        m_type = EStateType.EStateType_Move;
         
    }


    

    public override void OnEnterState()
    {
        base.OnEnterState();
    }

    public override void OnStartState()
    {
        base.OnStartState();
        if (entityview == null)
        {
            Goto(timeOutState);
            OnLeaveState();
        }
        m_animator = entityview.animator;
        if (m_animator != null)
        {
            m_animator.Play(EAnimationType.Move, 1.0f);
        }
    }

    public override void OnUpdateState()
    {
        base.OnUpdateState();
        //
        if(m_entityView == null)
        {
            Goto(timeOutState);
            OnLeaveState();
        }
        BaseAction cmd = m_entityView.actionManager.Pick();
        if(cmd.commandType == EActionType.EAction_Move)
        {
            MoveAction moveCmd = cmd as MoveAction;
            
        }
        Vector3 dir = endPos - startPos;
        m_entityView.position = startPos + (dir) * m_percent;

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

    
}
