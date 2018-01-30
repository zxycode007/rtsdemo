using UnityEngine;
using System.Collections;

public class GameManager : BaseObject
{

    public static GameManager instance;
    SceneController m_sceneController;
    

    void Awake()
    {
        instance = this;
        
        //加载别的场景时，不要销毁这个对象
        GameObject.DontDestroyOnLoad(this.gameObject);
        
    }

     void Start()   
    {
        m_sceneController = new SceneController();
        BaseState bs = new BaseState();
        bs.RegisterProperty(new StringProperty("name"));
        bs.SetProperty("name", "lily");
        object v = bs.GetPropertyValue("name");
        Debug.Log(v);
    }

    void Update()
     {

     }

    /// <summary>
    /// 控制当前游戏逻辑状态更新
    /// </summary>
    public void GameLogicOnUpdate()
    {
        m_sceneController.UpdateSceneState();
        
    }
    void Destory()
    {
        
        Debug.Log("结束游戏");
    }

    void OnApplicationQuit()
    {
        Debug.Log("程序退出");
    }
}
