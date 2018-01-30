using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public enum GameEventType
{
    //重新开始
    EVT_GAME_RESTART,
    //初始化
    EVT_GAME_INIT,
    //游戏状态切换
    EVT_GAME_SWITCH,

    //鼠标移动
    EVT_INPUT_MOUSE_MOVE,
    //鼠标键按下
    EVT_INPUT_MOUSE_BUTTON_DOWN,
    //鼠标键弹起 
    EVT_INPUT_MOUSE_BUTTON_UP,
    //操作杆方向改变
    EVT_INPUT_JOYSTICK_DIR_CHANGED,
    //操作按钮输入
    EVT_INPUT_JOYSTICK_BUTTON_DOWN,
}

public class GameEvtArg : EventArgs
{
    public DataBuffer m_buf;

    public GameEvtArg()
        : base()
    {

    }
    public GameEvtArg(DataBuffer buf)
        : base()
    {
        m_buf = buf;
    }

}

public delegate void GameEventHandler(object sender, EventArgs arg);

public class GameEventContext
{
    //public event EventHandler GameRestartHandler;
    //public event EventHandler GameInitHandler;
    //public event EventHandler GameSwitchHandler;

    //public event EventHandler InputMouseMoveHandler;
    //public event EventHandler InputMouseButtonDownHandler;
    //public event EventHandler InputMouseButtonUpHandler;
    //public event EventHandler InputJoystickDirChangeHandler;
    //public event EventHandler InputJoystickBtnDownHandler;

    

    Dictionary<GameEventType, GameEventHandler> m_handlerDict;

    public GameEventContext()
    {
        m_handlerDict = new Dictionary<GameEventType, GameEventHandler>();
    }

    public void FireEvent(object sender, GameEventType type, EventArgs arg)
    {
        if (GameEventManager.instance.EventReceivers == null)
            return;
        if (GameEventManager.instance.EventReceivers.ContainsKey(type))
        {
            HashSet<GameEventContext> set = GameEventManager.instance.EventReceivers[type];
            foreach (GameEventContext context in set)
            {
                if (context != null)
                {
                    context.OnEvent(sender, type, arg);
                }
            }
        }

    }

    public void Bind(GameEventType type, GameEventHandler handler)
    {
        if (m_handlerDict.ContainsKey(type) && m_handlerDict[type] != null)
        {
            m_handlerDict[type] += handler;
        }else
        {
            m_handlerDict[type] = handler;
        }
    }

    public void UnBind(GameEventType type, GameEventHandler handler)
    {
        if (m_handlerDict.ContainsKey(type) && m_handlerDict[type] != null)
        {
            m_handlerDict[type] -= handler;
        }
        
    }

    public void OnEvent(object sender, GameEventType type, EventArgs arg)
    {
        if(m_handlerDict.ContainsKey(type) && m_handlerDict[type] != null)
        {
            m_handlerDict[type](sender, arg);
        }
    }

    //public void Bind(GameEventType type, EventHandler handler)
    //{
    //    switch (type)
    //    {
    //        case (GameEventType.EVT_GAME_RESTART):
    //            {
    //                GameRestartHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_GAME_INIT):
    //            {
    //                GameInitHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_GAME_SWITCH):
    //            {
    //                GameSwitchHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_MOVE):
    //            {
    //                InputMouseMoveHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN):
    //            {
    //                InputMouseButtonDownHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_BUTTON_UP):
    //            {
    //                InputMouseButtonUpHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_JOYSTICK_DIR_CHANGED):
    //            {
    //                InputJoystickDirChangeHandler += handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN):
    //            {
    //                InputJoystickBtnDownHandler += handler;
    //                break;
    //            }
    //    }
    //}

    //public void UnBind(GameEventType type, EventHandler handler)
    //{
    //    switch (type)
    //    {
    //        case (GameEventType.EVT_GAME_RESTART):
    //            {
    //                GameRestartHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_GAME_INIT):
    //            {
    //                GameInitHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_GAME_SWITCH):
    //            {
    //                GameSwitchHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_MOVE):
    //            {
    //                InputMouseMoveHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN):
    //            {
    //                InputMouseButtonDownHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_BUTTON_UP):
    //            {
    //                InputMouseButtonUpHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_JOYSTICK_DIR_CHANGED):
    //            {
    //                InputJoystickDirChangeHandler -= handler;
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN):
    //            {
    //                InputJoystickBtnDownHandler -= handler;
    //                break;
    //            }
    //    }
    //}


    //public void OnEvent(object sender, GameEventType type, EventArgs arg)
    //{
    //    switch (type)
    //    {
    //        case (GameEventType.EVT_GAME_RESTART):
    //            {
    //                if (GameRestartHandler != null)
    //                {
    //                    GameRestartHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_GAME_INIT):
    //            {
    //                if (GameInitHandler != null)
    //                {
    //                    GameInitHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_GAME_SWITCH):
    //            {
    //                if (GameSwitchHandler != null)
    //                {
    //                    GameSwitchHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_MOVE):
    //            {
    //                if (InputMouseMoveHandler != null)
    //                {
    //                    InputMouseMoveHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_BUTTON_DOWN):
    //            {
    //                if (InputMouseButtonDownHandler != null)
    //                {
    //                    InputMouseButtonDownHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_MOUSE_BUTTON_UP):
    //            {
    //                if (InputMouseButtonUpHandler != null)
    //                {
    //                    InputMouseButtonUpHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_JOYSTICK_DIR_CHANGED):
    //            {
    //                if (InputJoystickDirChangeHandler != null)
    //                {
    //                    InputJoystickDirChangeHandler(sender, arg);
    //                }
    //                break;
    //            }
    //        case (GameEventType.EVT_INPUT_JOYSTICK_BUTTON_DOWN):
    //            {
    //                if (InputJoystickBtnDownHandler != null)
    //                {
    //                    InputJoystickBtnDownHandler(sender, arg);
    //                }
    //                break;
    //            }
    //    }
    //}
}

