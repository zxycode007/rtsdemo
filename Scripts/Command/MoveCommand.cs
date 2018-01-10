using UnityEngine;
using System.Collections;

public class MoveCommand : BaseCommand
{

    Vector3 m_curPos;
    Vector3 m_targetPos;


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
