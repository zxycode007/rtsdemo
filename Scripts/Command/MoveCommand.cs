using UnityEngine;
using System.Collections;

/// <summary>
/// 移动命令
/// 进入移动状态,长期状态
/// </summary>
public class MoveCommand : BaseCommand
{

    public MoveCommand()
    {
        mType = ECommandType.ECommand_Move;
        m_bRunning = false;
        m_bFinished = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if (m_entiyView == null)
        {
            m_bFinished = true;
        }
           
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        run();
    }

    public override void OnLeave()
    {
        base.OnLeave();
    }

    public override void run()
    {
        
    }
}
