using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertySystem
{

     List<PropertySet> m_propSets;
     PropertySet m_root;

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
      /// 如果没有父属性，则父属性为root节点； 如果没有root节点，则该属性集作为root节点
      /// </summary>
      /// <param name="name">属性集名</param>
      /// <param name="path">路径</param>
      public void NewPropertySet(string name, string path)                                                                                                                  
      {
           string[] pathNodes = path.Split('/');
           int index = 0;
           PropertySet parent = m_root;
           if (parent == null)
               return;
           while(parent != null)
           {
               if (parent.name != pathNodes[index])
                   return;
               index++;
               if (index < pathNodes.Length)
               {
                   parent = parent.FindChild(pathNodes[index]);
               }else
               {
                   //路径结束
                   break;
               }
           }
           PropertySet newNode = new PropertySet(name, this);
           if(parent != null)
           {
               newNode.parent = parent;
               parent.childs.Add(newNode.name, newNode); 
           }
      }
    
}
