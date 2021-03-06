﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EFSM_TYPE
{
    EFSM_ENTITY_FSM,
    EFSM_DEFAULT_FSM
}

public class BaseFSM  
{

    EntityView m_entityview;
    EntityAnimator m_animator;
    BaseState m_curState;
    //可能一个实体有多个部件，每个部件都有一个状态机，并且类型可能相同, 所以用名字来做唯一区分
    public string m_name;
    //指定状态机类型
    protected EFSM_TYPE m_type;

    //状态节点
    protected List<BaseState> m_stateNodes;

    protected BaseState m_defaultNode;

     

    public BaseState currentState
    {
        get
        {
            return m_curState;
        }
        set
        {
            m_curState = value;
            
        }
    }

    public BaseState defaultNode
    {
        get
        {
            return m_defaultNode;
        }
        set
        {
            m_defaultNode = value;
        }
    }

    public List<BaseState> states
    {
        get
        {
            return m_stateNodes;
        }
    }
    
    public EFSM_TYPE type
    {
        get
        {
            return m_type;
        }
    }

    public string name
    {
        get
        {
            return m_name;
        }
        set
        {
            m_name = value;
        }
    }

    public EntityView entityview
    {
        get
        {
            return m_entityview;
        }
        set
        {
            m_entityview = value;
            m_animator = value.animator;
            
        }
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {
        if (m_curState != null)
            m_curState.OnUpdateState();
    }

    public virtual void OnLeave()
    {
        
    }

    public int NodesCount
    {
        get
        {
            return m_stateNodes.Count;
        }
    }

    public virtual void AddStateNode(BaseState state)
    {
        if(state.curFSM != this)
        {
            state.curFSM.RemoveStateNode(state);
        }
        m_stateNodes.Add(state);
        state.curFSM = this;
    }

    public virtual void RemoveStateNode(BaseState state)
    {
        m_stateNodes.Remove(state);
    }

    public virtual BaseState GetStateNode(int index)
    {
        if (index > m_stateNodes.Count)
            return null;
        return m_stateNodes[index];
    }


    public BaseFSM()
    {
        m_stateNodes = new List<BaseState>();
        m_type = EFSM_TYPE.EFSM_DEFAULT_FSM;
    }

    public virtual BaseState FindChildState(string name)
    {
        foreach (BaseState state in states)
        {
            if (state.name == name)
            {
                return state;
            }
        }
        return null;
    }

    public virtual BaseFSM Clone()
    {
        BaseFSM cfsm = new BaseFSM();
        cfsm.name = m_name;

        foreach(BaseState snode in m_stateNodes)
        {
            BaseState cnode = snode.Clone();
            cnode.curFSM = cfsm;
            cfsm.states.Add(snode);
        }
        BaseState defaultNode = cfsm.FindChildState(m_defaultNode.name);
        if(defaultNode != null)
        {
            //设置当前默认状态
            cfsm.currentState = defaultNode;
            cfsm.defaultNode = defaultNode;
        }
        
        return cfsm;
    }
    
     
    
    
}
