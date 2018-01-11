using UnityEngine;
using System.Collections;

public class CommandManager
{
    PriorityQueue<BaseCommand> m_commadQueue;

    public void Enqueue(BaseCommand cmd)
    {
        m_commadQueue.Enqueue(cmd);
        
    }

    public BaseCommand Dequeue()
    {
        return m_commadQueue.Dequeue();
    }

    public BaseCommand Pick()
    {
        return m_commadQueue.Pick();
    }

    public CommandManager()
    {
        m_commadQueue = new PriorityQueue<BaseCommand>(BaseCommand.Compare);

    }
     
    public void Update()
    {

    }

}
