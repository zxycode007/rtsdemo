using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    Dictionary<GameEventType, HashSet<GameEventContext>> eventReceivers;
    public Dictionary<GameEventType, HashSet<GameEventContext>> EventReceivers
    {
        get
        {
            return eventReceivers;
        }
    }
    void Awake()
    {
        instance = this;
    }


    public void AddEventReceiver(GameEventType evt, GameEventContext context, EventHandler handler)
    {
        if (handler == null)
            return;
        if (eventReceivers == null)
        {
            eventReceivers = new Dictionary<GameEventType, HashSet<GameEventContext>>();
        }
        if (eventReceivers.ContainsKey(evt) == false || eventReceivers[evt] == null)
        {
            HashSet<GameEventContext> set = new HashSet<GameEventContext>();
            eventReceivers.Add(evt, set);
        }
        context.Bind(evt, handler);
        eventReceivers[evt].Add(context);
    }

    public void RemoveEventReceiver(GameEventType evt, GameEventContext context, EventHandler handler)
    {
        
        if (eventReceivers == null)
        {
            eventReceivers = new Dictionary<GameEventType, HashSet<GameEventContext>>();
        }
        if (!eventReceivers.ContainsKey(evt))
            return;
        if(handler != null)
            context.UnBind(evt, handler);
        eventReceivers[evt].Remove(context);
    }
}
