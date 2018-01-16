using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class FSMManager :BaseObject
{
    public static FSMManager instance;

    LogicEntityFSM entityFSM;
    void Awake()
    {
        instance = this;
    }

    public void LoadFSMConfig(EFSM_TYPE type)
    {
        switch(type)
        {
            case EFSM_TYPE.EFSM_ENTITY_FSM:
                entityFSM = LoadEntityFSMSchema();
                break;

        }
    }

    public LogicEntityFSM LoadEntityFSMSchema()
    {
        LogicEntityFSM fsm = new LogicEntityFSM();
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;
        string data = Resources.Load("Scp/FSMConfig.xml").ToString();
        xml.LoadXml(data);
        XmlNodeList fsmList = xml.ChildNodes;
        foreach (XmlNode node in fsmList)
        {
            Debug.Log(node.Name);
        }
        return fsm;
    }
}
