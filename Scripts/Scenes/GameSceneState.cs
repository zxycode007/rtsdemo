using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GameSceneState : BaseSceneState
{

    public GameSceneState(SceneController controller)
        : base(controller)
    {
        this.m_sceneName = "1";
        this.m_eState = ESceneState.E_SCENE_STATE_GAME;
        SceneManager.sceneLoaded += OnSceneLoaded;
        UnityEngine.Random.InitState(1);

    }

    public override void SceneStateBegin()
    {
        m_bRunning = true;
        TimeManager.instance.Reset();
    }


    public void OnQuitGame()
    {
        Application.Quit();
    }



    void OnDestroy()
    {

    }




    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == m_sceneName)
        {
            Debug.Log("场景加载完成!");
            m_bLoaded = true;
        }
    }

    public override void SceneStateEnd()
    {

    }

    //属于该场景逻辑交由该场景自己更新
    public override void SceneStateUpdate()
    {
        EntityManager.instance.LogicUpdate();
    }
}
