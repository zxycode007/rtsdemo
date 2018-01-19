using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class LoginSceneState : BaseSceneState
{


    public LoginSceneState(SceneController controller)
        : base(controller)
    {
        this.m_sceneName = "LoginScene";
        this.m_eState = ESceneState.E_SCENE_STATE_LOGIN;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void SceneStateBegin()
    {
        m_bRunning = true;
        GameEventManager.instance.AddEventReceiver(GameEventType.EVT_GAME_SWITCH, m_context, OnStartGame);
        m_bLoaded = true;
        TimeManager.instance.Reset();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == m_sceneName)
        {
            m_bLoaded = true;
        }

    }

    void OnStartGame(object sender, EventArgs arg)
    {
        Debug.Log("OnStartGame");
        m_controller.SwitchSceneState(ESceneState.E_SCENE_STATE_GAME);
    }

    public override void SceneStateEnd()
    {
        //GameEventManager.instance.RemoveEventReceiver(GameEventType.EVT_GAME_SWITCH, m_context, OnStartGame);
    }


    public override void SceneStateUpdate()
    {
         
    }
}
