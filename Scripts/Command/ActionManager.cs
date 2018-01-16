using UnityEngine;
using System.Collections;

public class ActionManager
{
    PriorityQueue<BaseAction> m_actionQueue;

    public void Enqueue(BaseAction cmd)
    {
        m_actionQueue.Enqueue(cmd);
        
    }

    public BaseAction Dequeue()
    {
        return m_actionQueue.Dequeue();
    }

    public BaseAction Pick()
    {
        return m_actionQueue.Pick();
    }

    public ActionManager()
    {
        m_actionQueue = new PriorityQueue<BaseAction>(BaseAction.Compare);

    }
     
    public void Update()
    {

    }

}
