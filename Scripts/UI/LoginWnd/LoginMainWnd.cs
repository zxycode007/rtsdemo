using UnityEngine;
using System.Collections;

public class LoginMainWnd : BaseObject
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickStartBtn()
    {
        DataBuffer da = new DataBuffer();
        da.WriteInt((int)ESceneState.E_SCENE_STATE_GAME);
        evtCtx.FireEvent(this, GameEventType.EVT_GAME_SWITCH, new GameEvtArg(da));   
    }
}
