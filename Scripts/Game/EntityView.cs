﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityView : BaseObject
{
    private EntityAnimator m_animator;
    private int m_uid;
    private Dictionary<string, BaseFSM> m_fsmDict;
    //暂时世界坐标位置
    private Vector3 m_pos;
    ActionManager m_actionMgr;

    public ActionManager actionManager
    {
        get
        {
            return m_actionMgr;
        }
    }

    public Vector3 position
    {
        get
        {
            return m_pos;
        }
        set
        {
            m_pos = value;
        }
    }

    public int uid
    {
        get
        {
            return m_uid;
        }
    }

    public BaseAction GetCurrentAction()
    {
        return m_actionMgr.Pick();
    }
    public void SetFSM(string fsmName, BaseFSM fsm)
    {
        m_fsmDict[fsmName] = fsm;
    }

    public BaseFSM GetFSM(string fsmName)
    {
        return m_fsmDict[fsmName];
    }

    void Awake()
    {
        m_animator = gameObject.GetComponent<EntityAnimator>();
        m_uid = gameObject.GetHashCode();
        m_fsmDict = new Dictionary<string, BaseFSM>();
        m_actionMgr = new ActionManager();
        LogicEntityFSM entityFSM = FSMManager.instance.CreateFSM("EntityActionFSM") as LogicEntityFSM;

    }

    // Use this for initialization
    void Start()
    {

    }

    void UpdateFSM()
    {

    }
    /// <summary>
    /// 逻辑更新
    /// </summary>
    public void LogicUpdate()
    {
        m_actionMgr.Update();
        UpdateFSM();

    }

    // Update is called once per frame
    void Update()
    {
        //更新实体位置
        transform.position = position;
    }

    public EntityAnimator animator
    {
        get
        {
            return animator;
        }
       
    }
}
