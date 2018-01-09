using UnityEngine;
using System.Collections;

public class SceneController : BaseObject
{
    public static SceneController instance;

    void Awake()
    {
        instance = this;
        evtCtx = new GameEventContext();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
