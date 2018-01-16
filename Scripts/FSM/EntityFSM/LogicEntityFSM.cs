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

    public override void LoadSchema(string fileName)
    {
        
    }
}
