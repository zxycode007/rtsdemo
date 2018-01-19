using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;


 

public class LogicEntityFSM : BaseFSM
{
    

    public LogicEntityFSM():base()
    {
        m_type = EFSM_TYPE.EFSM_ENTITY_FSM;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnLeave()
    {
        base.OnLeave();
    }

    public void OnCommand(EActionType action,  byte[] param)
    {
        if (currentState != null)
        {
            LogicEntityState state = currentState as LogicEntityState;
            state.OnCommand(action, param);
        }
        
    }

    public override BaseFSM Clone()
    {
        LogicEntityFSM cfsm = new LogicEntityFSM();
        cfsm.name = m_name;

        foreach (BaseState snode in m_stateNodes)
        {
            BaseState cnode = snode.Clone();
            cnode.curFSM = cfsm;
            cfsm.states.Add(snode);
        }
        BaseState defaultNode = cfsm.FindChildState(m_defaultNode.name);
        if (defaultNode != null)
        {
            cfsm.AddStateNode(defaultNode);
        }

        return cfsm;
    }

   
}
