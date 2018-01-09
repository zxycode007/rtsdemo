using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 游戏对象基类
/// </summary>
public class BaseObject: MonoBehaviour {

    protected GameEventContext evtCtx = new GameEventContext();

    void Awake()
    {
        
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 重新设初值
    /// </summary>
    public virtual void Reset()
    {

    }



    /// <summary>
    /// 回收处理方法
    /// </summary>
    public virtual void Recycle()
    {

    }
}
