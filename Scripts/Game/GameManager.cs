using UnityEngine;
using System.Collections;

public class GameManager : BaseObject
{

    public static GameManager instance;
    CommandManager m_commandMgr;

    public CommandManager commandManager
    {
        get
        {
            return m_commandMgr;
        }
    }

    void Awake()
    {
        instance = this;
        m_commandMgr = new CommandManager();
    }

     void Start()
    {

    }

    void Update()
     {

     }

    /// <summary>
    /// 状态机，命令应该都在里面更新
    /// </summary>
    public void GameLogicOnUpdate()
    {
        m_commandMgr.Update();
        EntityManager.instance.LogicUpdate();
    }

}
