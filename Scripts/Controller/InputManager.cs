using UnityEngine;
using System.Collections;

public class InputManager : BaseObject
{

    public static InputManager instance;

    //public float mouseMoveDeadZone;

    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
         
 
    }

    // Update is called once per frame
    void Update()
    {
        //鼠标右键按下
        if (Input.GetMouseButton((int)EMouseButton.E_MOUSE_RIGHT))
        {
            DataBuffer buf = new DataBuffer();
            buf.WriteByte(0);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN, new GameEvtArg(buf));

        }
        //鼠标右键弹起
        if(Input.GetMouseButtonUp((int)EMouseButton.E_MOUSE_RIGHT))
        {
            DataBuffer buf = new DataBuffer();
            buf.WriteByte(0);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_MOUSE_BUTTON_UP, new GameEvtArg(buf));

        }
        float deltaX = Input.GetAxis("Mouse X");
        float deltaY = Input.GetAxis("Mouse Y");
         
        {   
            DataBuffer buf = new DataBuffer();
            buf.WriteFloat(deltaX);
            buf.WriteFloat(deltaY);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_MOUSE_MOVE, new GameEvtArg(buf));
        }
        KeyCode code = KeyCode.None;
        if(Input.GetKeyDown(KeyCode.W))
        {
            code = KeyCode.W;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_DOWN, new GameEvtArg(buf));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            code = KeyCode.S;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_DOWN, new GameEvtArg(buf));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            code = KeyCode.A;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_DOWN, new GameEvtArg(buf));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            code = KeyCode.D;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_DOWN, new GameEvtArg(buf));
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            code = KeyCode.W;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_UP, new GameEvtArg(buf));
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            code = KeyCode.S;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_UP, new GameEvtArg(buf));
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            code = KeyCode.A;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_UP, new GameEvtArg(buf));
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            code = KeyCode.D;
            DataBuffer buf = new DataBuffer();
            buf.WriteInt((int)code);
            evtCtx.FireEvent(this, GameEventType.EVT_INPUT_KEYBOARD_KEY_UP, new GameEvtArg(buf));
        }
        

    }
}
