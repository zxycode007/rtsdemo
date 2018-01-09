using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JoyStickInputPad : MonoBehaviour
{

    public Button LPunchBtn;
    public Button LPunchMoveBtn;
    public Button RPunchBtn;
    public Button RPunchMoveBtn;
    public Button LKickBtn;
    public Button RKickBtn;
    public GameEventContext m_EvtCtx;
    
    public void OnLPunch()
    {
        Debug.Log("LPunch!");
        DataBuffer dbuf = new DataBuffer();
        dbuf.WriteByte(0);
        GameEvtArg arg = new GameEvtArg(dbuf);
        m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, arg);
    }

    public void OnRPunch()
    {
        Debug.Log("RPunch!");
        DataBuffer dbuf = new DataBuffer();
        dbuf.WriteByte(1);
        GameEvtArg arg = new GameEvtArg(dbuf);
        m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, arg);
    }
    public void OnLPunchMove()
    {
        Debug.Log("LPunchMove!");
        DataBuffer dbuf = new DataBuffer();
        dbuf.WriteByte(2);
        GameEvtArg arg = new GameEvtArg(dbuf);
        m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, arg);
    }
    public void OnRPunchMove()
    {
        Debug.Log("RPunchMove!");
        DataBuffer dbuf = new DataBuffer();
        dbuf.WriteByte(3);
        GameEvtArg arg = new GameEvtArg(dbuf);
        m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, arg);
    }

    public void OnLKick()
    {
        Debug.Log("LKick!");
        DataBuffer dbuf = new DataBuffer();
        dbuf.WriteByte(4);
        GameEvtArg arg = new GameEvtArg(dbuf);
        m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, arg);
    }

    public void OnRKick()
    {
        Debug.Log("RKick!");
        DataBuffer dbuf = new DataBuffer();
        dbuf.WriteByte(5);
        GameEvtArg arg = new GameEvtArg(dbuf);
        m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN, arg);
    }

    void Awake()
    {
        m_EvtCtx = new GameEventContext();
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
