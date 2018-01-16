using UnityEngine;
using System.Collections;

public class GameManager : BaseObject
{

    public static GameManager instance;
    

    void Awake()
    {
        instance = this;
        
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
        EntityManager.instance.LogicUpdate();
    }

}
