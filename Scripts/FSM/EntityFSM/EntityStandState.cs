using UnityEngine;
using System.Collections;

public class EntityStandState : BaseState
{

    public EntityStandState():base()
    {
        m_type = EStateType.EStateType_Stand;
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
        EntityAnimator animator = entityview.animator;
        if (animator != null)
        {
            animator.Play(EAnimationType.Stand, 1.0f);
        }
    }

    public override void OnUpdateState()
    {
        base.OnUpdateState();



    }

    public override void OnEndState()
    {
        base.OnEndState();
    }

    public override void OnLeaveState()
    {
        base.OnLeaveState();
    }
    
}
