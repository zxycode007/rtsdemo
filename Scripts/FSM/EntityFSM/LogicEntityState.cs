using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public override BaseState Clone()
    {
        LogicEntityState cloneObj = new LogicEntityState();
        cloneObj.durationTick = this.durationTick;
        cloneObj.name = this.name;
        foreach (KeyValuePair<int, StateLink> kv in m_links)
        {
            StateLink link = new StateLink();
            link.linkID = kv.Value.linkID;
            link.linkStateName = kv.Value.linkStateName;
            cloneObj.m_links[link.linkID] = link;
        }
        return cloneObj;
    }
}
