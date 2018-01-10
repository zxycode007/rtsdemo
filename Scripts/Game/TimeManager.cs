using UnityEngine;
using System.Collections;

public class TimeManager : BaseObject
{

    public static TimeManager instance;
    /// <summary>
    /// 当前渲染总帧数
    /// </summary>
    long m_curTicks = 0;
    /// <summary>
    /// 当前逻辑帧时间
    /// </summary>
    float m_curLogicFrameTime;
    /// <summary>
    /// 设定帧率 默认30帧
    /// </summary>
    float m_frameRatePerSecond = 30;
    float m_frameTime;

    float m_accTime = 0;

    /// <summary>
    /// 本地tick数
    /// </summary>
    public long localTickCount
    {
        get
        {
            return m_curTicks;
        }
    }

    public long GetCurTick()
    {
        return localTickCount;
    }

    public float CurLogicFrameTime
    {
        get
        {
            return m_curLogicFrameTime;
        }
        set
        {
            m_curLogicFrameTime = value;
        }
    }

    public float FrameTime
    {
        get
        {
            return m_frameTime;
        }
    }

    public float FrameRate
    {
        get
        {
            return m_frameRatePerSecond;
        }
        set
        {
            m_frameRatePerSecond = value;
            if (Mathf.Abs(m_frameRatePerSecond) < 10)
            {
                Debug.LogError("FrameRate太低");
                m_frameRatePerSecond = 10;
            }
            m_frameTime = 1 / m_frameRatePerSecond;

        }
    }

    public float GetDeltaTime()
    {
        return CurLogicFrameTime;
    }

    void Awake()
    {
        instance = this;
        m_frameTime = 1.0f / m_frameRatePerSecond;
        m_curLogicFrameTime = 1.0f / m_frameRatePerSecond;

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_accTime += Time.deltaTime;
        //只有大于设定的帧时间时才更新
        while (m_accTime > m_frameTime)
        {
            CurLogicFrameTime = m_frameTime;
            m_curTicks++;
            m_accTime = m_accTime - m_frameTime;
        }
    }

    public void Reset()
    {
        m_accTime = 0;
        m_curTicks = 0;
        m_frameTime = 1.0f / m_frameRatePerSecond;
        m_curLogicFrameTime = 1.0f / m_frameRatePerSecond;
    }
}
