using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Reflection;
using System;
public class FSMManager : BaseObject
{
    public static FSMManager instance;

    LogicEntityFSM entityFSM;
    void Awake()
    {
        instance = this;
        LoadFSMConfig(EFSM_TYPE.EFSM_ENTITY_FSM);
    }

    public void LoadFSMConfig(EFSM_TYPE type)
    {
        switch (type)
        {
            case EFSM_TYPE.EFSM_ENTITY_FSM:
                entityFSM = LoadEntityFSMSchema();
                break;

        }
    }

    public void ParseEntityFSM(XmlNode fsmNode)
    {
        if (fsmNode == null || fsmNode.Name != "FSM")
            return;
        LogicEntityFSM fsm = new LogicEntityFSM();
        XmlAttributeCollection attributes = fsmNode.Attributes;
        string fsmName = attributes.GetNamedItem("name").Value;
        string defaultNode = attributes.GetNamedItem("defaultNode").Value;
        
    }

    public LogicEntityState ParseEntityStateNode(XmlNode stateNode)
    {
        if (stateNode == null || stateNode.Name == "StateNode")
            return null;
        XmlAttributeCollection attributes = stateNode.Attributes;
        string stateName = attributes.GetNamedItem("name").Value;
        string stateType = attributes.GetNamedItem("type").Value;
        Assembly assembly = Assembly.GetExecutingAssembly();
        object obj = assembly.CreateInstance(stateType);
        if (obj == null)
        {
            Debug.Log("stateName create failed!");
            return null;
        }
        LogicEntityState entityState = obj as LogicEntityState;
        switch(entityState.type)
        {
            case EStateType.EStateType_LoginEntiy:
                {

                }
                break;
            case EStateType.EStateType_EntityAnimation:
                {
                    string outState = attributes.GetNamedItem("outState").Value;
                    string animationType = attributes.GetNamedItem("AnimationType").Value;
                    EntityAnimationState animatinState = entityState as EntityAnimationState;
                    animatinState.animantioName = animationType;
                    long durationTick = 0;
                    long.TryParse(attributes.GetNamedItem("duration").Value, out durationTick);
                    animatinState.durationTick = durationTick;
                    int loopCount = 0;
                    int.TryParse(attributes.GetNamedItem("loopCount").Value, out loopCount);
                    animatinState.loopCount = loopCount;
                    float animationSpeed = 0;
                    float.TryParse(attributes.GetNamedItem("AnimationSpeed").Value, out animationSpeed);
                    animatinState.animationSpeed = animationSpeed;
                    return animatinState;
                    
                }
                break;

        }


        return null;
        
    }

    public StateLink ParseStateLink(XmlNode linkNode)
    {
        return null;
    }


    public LogicEntityFSM LoadEntityFSMSchema()
    {
        XmlDocument xml = new XmlDocument();
        XmlReaderSettings set = new XmlReaderSettings();
        set.IgnoreComments = true;
        object obj = Resources.Load("Scp/EntityFSMConfig");
        if (obj != null)
        {
            string data = obj.ToString();
            xml.LoadXml(data);
            XmlNodeList fsmList = xml.ChildNodes;
            foreach (XmlNode node in fsmList)
            {
                if (node.Name == "FSM")
                {

                }


            }
        }
        return null;
    }
}
