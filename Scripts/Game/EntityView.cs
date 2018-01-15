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
    }

    // Use this for initialization
    void Start()
    {

    }

    /// <summary>
    /// 更新这个实体附带的所有状态机
    /// </summary>
    public void UpdateFSM()
    {

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
