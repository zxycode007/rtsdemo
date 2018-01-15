using UnityEngine;
using System.Collections;


/// <summary>
/// 移动去某个目的地命令
/// </summary>
public class MoveToCommand : BaseCommand
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


    public MoveToCommand()
    {
        mType = ECommandType.ECommand_MoveTo;
        m_bRunning = false;
        m_bFinished = false;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        if(m_entiyView == null)
        {
            m_bFinished = true;
        }
    }

    public override void OnLeave()
    {
        base.OnLeave();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
    
}
