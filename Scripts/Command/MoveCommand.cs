using UnityEngine;
using System.Collections;

public class MoveCommand : BaseCommand
{

    Vector3 m_curPos;
    Vector3 m_targetPos;

    public Vector3 curPos
    {
        get
        {
            return m_curPos;
        }
        set
        {
            m_curPos = value;
        }
    }

    public Vector3 targetPos
    {
        get
        {
            return m_targetPos;
        }
        set
        {
            m_targetPos = value;
        }
    }


    public MoveCommand()
    {
        mType = ECommandType.ECommand_Move;
        m_bRunning = false;
        m_bFinished = false;
    }

    public override void OnEnter()
    {
        
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        
    }
    
    
}
