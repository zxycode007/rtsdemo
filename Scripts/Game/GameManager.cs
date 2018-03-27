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
        Property pt1 = new StringProperty("pt1");
        Property pt2 = new Vector2Property("vpt");
        Property pt3 = new Matrix4x4Property("matpt");
        Property pt4 = new QuaternionProperty("qpt");
        pt2.value = new Vector2(23, 11);
        pt1.value = "test";
        pt3.value = Matrix4x4.identity;
        pt4.value = Quaternion.identity;
        Property pt5 = new ColorProperty("cpt");
        Property pt6 = new IntProperty("ipt");
        Property pt7 = new Vector3Property("v3pt");
        pt5.value = Color.red;
        pt6.value = 612;
        pt7.value = new Vector3(12, 11, 33);
        
        PropertySet ps = new PropertySet("pset",null);
        PrpertySetProperty pts = new PrpertySetProperty("pts");
        PropertySet ps2 = new PropertySet("pset2", null);
        ps2.SetProperty(pt5);
        ps2.SetProperty(pt6);
        ps2.SetProperty(pt7);
        pts.value = ps2;

        ps.SetProperty(pt1);
        ps.SetProperty(pt2);
        ps.SetProperty(pt3);
        ps.SetProperty(pt4);
        ps.SetProperty(pts);
        

        //bs.RegisterProperty(new StringProperty("name"));
        //bs.SetProperty("name", "lily");
        //object v = bs.GetPropertyValue("name");
        Property pt = ps.GetProperty("pt1");
        Debug.Log(pt.name +"  " +pt.value);
        pt = ps.GetProperty("vpt");
        Debug.Log(pt.name + "  " + pt.value);
        pt = ps.GetProperty("matpt");
        Debug.Log(pt.name + "  " + pt.value);
        pt = ps.GetProperty("qpt");
        Debug.Log(pt.name + "  " + pt.value);
        pt = ps.GetProperty("pts");
        PropertySet ps3 = pt.value as PropertySet;
        pt = ps3.GetProperty("cpt");
        Debug.Log(pt.name + "  " + pt.value);
        pt = ps3.GetProperty("ipt");
        Debug.Log(pt.name + "  " + pt.value);
        pt = ps3.GetProperty("v3pt");
        Debug.Log(pt.name + "  " + pt.value);
        //Debug.Log(pt2.name + "  " + pt2.value);
        //Debug.Log(pt3.name + "  " + pt3.value);
        //Debug.Log(pt4.name + "  " + pt4.value);
        

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
