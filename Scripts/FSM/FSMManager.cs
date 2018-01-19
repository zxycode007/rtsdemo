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


    Dictionary<string, BaseFSM> m_fsmTemplates;
    void Awake()
    {
        instance = this;
        m_fsmTemplates = new Dictionary<string, BaseFSM>();
        LoadFSMConfig();
    }

    public BaseFSM CreateFSM(string name)
    {
        if(m_fsmTemplates.ContainsKey(name))
        {
            return m_fsmTemplates[name].Clone();
        }
        return null;
    }

    public void LoadFSMConfig()
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
            //读取所有状态机节点
            foreach (XmlNode node in fsmList)
            {
                if (node.Name == "FSM")
                {
                    LoadFSMTemplate(node);
                }
            }
        }
        
    }

    public void LoadFSMTemplate(XmlNode fsmNode)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        if (fsmNode == null || fsmNode.Name != "FSM")
            return;
        object fsmObj = assembly.CreateInstance(fsmNode.Attributes.GetNamedItem("type").Value);
        if (fsmObj != null)
        {
            BaseFSM bfsm = fsmObj as BaseFSM;
            bfsm.name = fsmNode.Attributes.GetNamedItem("name").Value;
            switch(bfsm.type)
            {
                case EFSM_TYPE.EFSM_DEFAULT_FSM:
                    { 

                    }
                    break;
                case EFSM_TYPE.EFSM_ENTITY_FSM:
                    {

                    }break;
            }
            //先将所有节点生成一遍，再设置连接关系
            XmlNodeList stateNodes = fsmNode.ChildNodes;
            for (int i = 0; i<stateNodes.Count; i++)
            {
                XmlNode stateNode = stateNodes[i];
                if (stateNode.Name != null && stateNode.Name == "StateNode")
                {
                    //string t = typeof(EntityAnimationState).ToString();
                    //object stateObj = assembly.CreateInstance(t);
                    object stateObj = assembly.CreateInstance(stateNode.Attributes.GetNamedItem("type").Value);
                    if (stateObj != null)
                    {
                        BaseState state = stateObj as BaseState;
                        state.name = stateNode.Attributes.GetNamedItem("name").Value;
                        state.curFSM = bfsm;
                        int duration = 0;
                        int.TryParse(stateNode.Attributes.GetNamedItem("duration").Value, out duration);
                        state.durationTick = duration;
                        switch (state.type)
                        {
                            case EStateType.EStateType_LoginEntiy:
                                {

                                }
                                break;
                            case EStateType.EStateType_EntityAnimation:
                                {
                                    EntityAnimationState animState = state as EntityAnimationState;
                                    animState.animantioName = stateNode.Attributes.GetNamedItem("AnimationType").Value;
                                    float speed = 0;
                                    float.TryParse(stateNode.Attributes.GetNamedItem("AnimationSpeed").Value, out speed);
                                    animState.animationSpeed = speed;
                                    int loopCount = 0;
                                    int.TryParse(stateNode.Attributes.GetNamedItem("loopCount").Value, out loopCount);
                                    animState.loopCount = loopCount;
                                }
                                break;
                        }
                        for (int j = 0; j < stateNode.ChildNodes.Count; j++)
                        {
                            XmlNode linkNode = stateNode.ChildNodes[j];
                            object linkObj = assembly.CreateInstance("StateLink");
                            if (linkObj != null)
                            {
                                StateLink link = linkObj as StateLink;
                                object linkKey = Enum.Parse(typeof(EActionType), linkNode.Attributes.GetNamedItem("actionId").Value);
                                if (linkKey != null)
                                {
                                    link.linkID = (int)linkKey;
                                    link.linkStateName = linkNode.Attributes.GetNamedItem("linkStateName").Value;
                                    state.links.Add((int)linkKey, link);
                                }
                            }
                            bfsm.AddStateNode(state);
                        }

                    }
                }
            }
            object defaultNode = bfsm.FindChildState(fsmNode.Attributes.GetNamedItem("defaultNode").Value);
            if(defaultNode != null)
            {
                bfsm.defaultNode = defaultNode as BaseState;
            }
            //设置连接关系
            //foreach (XmlNode stateNode in fsmNode.ChildNodes)
            for (int i = 0; i < stateNodes.Count; i++ )
            {
                XmlNode stateNode = stateNodes[i];
                BaseState state = bfsm.FindChildState(stateNode.Attributes.GetNamedItem("name").Value);
                object outstate = bfsm.FindChildState(stateNode.Attributes.GetNamedItem("outState").Value);
                if (outstate != null)
                {
                    state.timeOutState = outstate as BaseState;
                }
            }
            //添加到FSM表
            m_fsmTemplates[bfsm.name] = bfsm;
        }



    }

    void Update()
    {
        //Debug.Log("sss");
    }
     
}
