using UnityEngine;
using System.Collections;

public class AttackCommand : BaseCommand
{

    public AttackCommand()
    {
        mType = ECommandType.ECommand_Attack;
        m_bFinished = false;
        m_bRunning = false;
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
