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

    

    
    
}
