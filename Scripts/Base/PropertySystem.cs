using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertySystem
{

    List<PropertySet> m_propSets;
    PropertySet m_root;
    bool m_bAutoCreateNode;

    public bool isAutoCreateNode
    {
        get
        {
            return m_bAutoCreateNode;
        }
        set
        {
            m_bAutoCreateNode = value;
        }
    }

    public List<PropertySet> PropertySetMap
    {
        get
        {
            return m_propSets;
        }
    }

    public PropertySystem()
    {
        m_propSets = new List<PropertySet>();
    }



    /// <summary>
    /// 新的属性集
    /// 插入新节点到指定路径节点下
    /// 如果没有父属性，则父属性为root节点； 如果没有root节点，则该属性集作为root节点
    /// </summary>
    /// <param name="name">属性集名</param>
    /// <param name="path">路径</param>
    public void NewPropertySet(string name, string path)
    {
        string[] pathNodes = path.Split('/');
        int index = 0;
        PropertySet parent = m_root;
        PropertySet newNode = new PropertySet(name, this);
        if (parent == null)
        {
            m_root = newNode;
            return;
        }
        //找新节点的parent
        while (parent != null)
        {
            //路径不匹配
            if (parent.name != pathNodes[index])
            {
                Debug.LogWarning("Path Error! " + parent.name + " != " + pathNodes[index]);
                return;
            }
            index++;
            //判断是否到了路径最后一个节点,到了退出
            if (index < pathNodes.Length)
            {
                parent = parent.FindChild(pathNodes[index]);
                //是否自动创建节点
                if (parent == null && isAutoCreateNode)
                {
                    parent = new PropertySet(pathNodes[index], this);
                }
            }
            else
            {
                //路径结束
                break;
            }
        }
        if (parent != null)
        {
            newNode.parent = parent;
            parent.childs.Add(newNode.name, newNode);
        }
        else
        {
            Debug.LogWarning("not found child!");
        }
    }

    public PropertySet GetPropertySet(string path)
    {
        PropertySet node = m_root;
        if (node == null)
            return null;
        string[] pathNodes = path.Split('/');
        int index = 0;
        while (node != null)
        {
            if (node.name != pathNodes[index])
            {
                Debug.LogWarning("path Error!");
                return null;
            }
            if (index <= pathNodes.Length - 1)
            {
                node = node.FindChild(pathNodes[index]);
            }
            index++;
            if (index > pathNodes.Length - 1)
            {
                break;
            }
        }
        return node;
    }

    /// <summary>
    /// 删除指定路径的属性集节点
    /// </summary>
    /// <param name="path">路径</param>
    public void DeletePropertySet(string path)
    {
        PropertySet node = m_root;
        if (node == null)
            return;
        string[] pathNodes = path.Split('/');
        int index = 0;
        while(node != null)
        {
            if (node.name != pathNodes[index])
            {
                Debug.LogWarning("path Error!");
                return;
            }
            if(index <=  pathNodes.Length -1 )
            {
                node = node.FindChild(pathNodes[index]);
            }
            index++;
            if(index > pathNodes.Length -1)
            {
                break;
            }
        }
        if(node != null)
        {
            node.parent.childs.Remove(node.name);
            node.parent = null;
        }
    }

    public void Clear()
    {
        m_propSets.Clear();
        m_root = null;
    }

}
