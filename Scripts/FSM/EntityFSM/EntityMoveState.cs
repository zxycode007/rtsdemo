using UnityEngine;
using System.Collections;

public class EntityMoveState : BaseState
{
    public Vector3 startPos;
    public Vector3 endPos;
    

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
            OnLeaveState();
        EntityAnimator animator = entityview.animator;
        if(animator != null)
        {
            animator.Play(EAnimationType.Move, 1.0f);
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
