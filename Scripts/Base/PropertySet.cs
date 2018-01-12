using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertySet
{
    Dictionary<string, int> m_propertyNameMap;
    List<Property> m_propertyList;
    PropertySet m_parent;
    Dictionary<string, PropertySet> m_childs;
    PropertySystem m_system;


    //属性类名
    string m_name;
    

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

    public PropertySet parent
    {
        get
        {
            return parent;
        }
        set
        {
            parent = value;
        }
    }

    public Dictionary<string, PropertySet> childs
    {
        get
        {
            return m_childs;
        }
    }

    public PropertySet FindChild(string name)
    {
        if(m_childs.ContainsKey(name))
        {
            return m_childs[name];
        }
        return null;
    }
    


    public PropertySet(string name, PropertySystem sys)
    {
        m_propertyNameMap = new Dictionary<string, int>();
        m_propertyList = new List<Property>();
        m_childs = new Dictionary<string, PropertySet>();
        m_name = name;
        m_system = sys;
    }

    public Property GetProperty(string name)
    {
        int index = -1;
        if(m_propertyNameMap.ContainsKey(name))
        {
            index = m_propertyNameMap[name];
            return m_propertyList[index];
        }
        return null;
        
    }

    public Property GetProperty(int index)
    {
        if(index < m_propertyList.Count)
        {
            return m_propertyList[index];
        }
        return null;
    }
    
    public void SetProperty(Property prop)
    {
        int index = -1;
        if(m_propertyNameMap.ContainsKey(prop.name))
        {
            index = m_propertyNameMap[prop.name];
            m_propertyList[index] = prop;
        }else
        {
            m_propertyList.Add(prop);
            index = m_propertyList.Count -1;
            m_propertyNameMap[prop.name] = index;
        }
    }

    public void RemvoeProperty(string name)
    {
        int index = -1;
        if (m_propertyNameMap.ContainsKey(name))
        {
            index = m_propertyNameMap[name];
            m_propertyList.RemoveAt(index);
        }
    }

    public void RemoveProperty(int index)
    {
        if (index < m_propertyList.Count)
        {
            m_propertyList.RemoveAt(index);
        }
    }

    public void Clear()
    {
        m_propertyList.Clear();
        m_propertyNameMap.Clear();
    }

    public int Count
    {
        get
        {
            return m_propertyNameMap.Count;
        }

    }
}
