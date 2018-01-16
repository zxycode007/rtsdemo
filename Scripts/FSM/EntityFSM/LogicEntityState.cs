using UnityEngine;
using System.Collections;

public class LogicEntityState : BaseState
{

    public LogicEntityState():base()
    {
        m_type = EStateType.EStateType_LoginEntiy;
    }

    public virtual void OnCommand(EActionType action, byte[] param)
    {
        int id = (int)action;
        if(links.ContainsKey(id))
        {
            StateLink link = links[id];
            BaseState outstate = curFSM.FindChildState(link.linkStateName);
            Goto(outstate);
        }
    }

    public override void OnStartState()
    {
        base.OnStartState();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
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
