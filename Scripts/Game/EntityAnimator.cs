using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum EAnimationType
{
    Stand,
    Move,
    LPunch,
    RPunch,
    LPunchMove,
    RPunchMove,
    LKick,
    RKick

}

public class AnimationTriggerNode
{
    string m_triggerName;
    AnimationTriggerNode m_parent;
    List<AnimationTriggerNode> m_childs;
    bool m_isActived;
    public AnimationTriggerNode(string triggerName)
    {
        m_isActived = false;
        m_triggerName = triggerName;
        m_parent = null;
        m_childs = new List<AnimationTriggerNode>();
    }

    public AnimationTriggerNode(string triggerName, AnimationTriggerNode parent)
    {
        m_triggerName = triggerName;
        m_parent = parent;
        m_childs = new List<AnimationTriggerNode>();
        m_isActived = false;
    }

    public bool isActived
    {
        get
        {
            return m_isActived;
        }
        set
        {
            m_isActived = value;
        }
    }

    public string triggerName
     {
         get
         {
             return m_triggerName;
         }
        set
         {
             m_triggerName = value;
         }
     }

    public AnimationTriggerNode Parent
    {
        get
        {
            return m_parent;
        }
        set
        {
            if (m_parent != null)
            {
                if (m_parent.Childs.Contains(this))
                {
                    m_parent.Childs.Remove(this);
                };
            }
            m_parent = value;
            m_parent.Childs.Add(this);
            
        }
    }

    public List<AnimationTriggerNode> Childs
    {
        get
        {
            return m_childs;
        }
    }



}

public class AnimationTriggerManager
{
    AnimationTriggerNode m_root;
    Animator m_animator;
    Dictionary<string, AnimationTriggerNode> m_triggers;
    public AnimationTriggerManager(Animator animator, string root)
    {
        m_triggers = new Dictionary<string, AnimationTriggerNode>();
        m_animator = animator;
        m_root = new AnimationTriggerNode(root);
        m_triggers[root] = m_root;
    }

    public void init()
    {

    }

    public void  Add(string trigger, string parentTrigger)
    {
        if (m_triggers.ContainsKey(trigger))
            return;
        AnimationTriggerNode node = new AnimationTriggerNode(trigger);
        if(m_triggers.ContainsKey(parentTrigger))
        {
            AnimationTriggerNode parent = m_triggers[parentTrigger];
            if(parent != null)
            {
                node.Parent = parent;
                m_triggers[trigger] = node;
                return;
            }
        }
        node.Parent = m_root;
        m_triggers[trigger] = node;
    }



    public void Clear()
    {
        m_root = null;
        m_triggers.Clear();
    }
    public void Remove(string trigger)
    {
        if(m_triggers.ContainsKey(trigger))
        {
            AnimationTriggerNode node = m_triggers[trigger];
            if(node != null)
            {
                node.Parent.Childs.Remove(node);
                for(int i=0 ; i<node.Childs.Count; i++)
                {
                    node.Childs[i].Parent = node.Parent;
                }
                m_triggers.Remove(trigger);
            }
        }
    }

    public void ResetTrigger()
    {
        if (m_animator == null)
            return;
        foreach(KeyValuePair<string, AnimationTriggerNode> kv in m_triggers)
        {
            kv.Value.isActived = false;
            m_animator.ResetTrigger(kv.Value.triggerName);
        }
    }

    public AnimationTriggerNode GetTrigger(string trigger)
    {
        if(m_triggers.ContainsKey(trigger))
        {
            return m_triggers[trigger];
        }
        return null;
    }

    public void OnTrigger(string trigger)
    {
        if (m_root == null)
            return;
        if(m_triggers.ContainsKey(trigger))
        {
            //触发器链
            //不触发root节点的Trigger，触发就返回root了
            AnimationTriggerNode node = m_triggers[trigger];
            if(node == m_root)
            {
                m_animator.SetTrigger(node.triggerName);
                node.isActived = true;
                return;
            }
            while(node != null && node != root)
            {
                m_animator.SetTrigger(node.triggerName);
                node.isActived = true;
                node = node.Parent;
            }
        }
    }

    public AnimationTriggerNode root
    {
        get
        {
           return m_root;
        }
    }

}



public class EntityAnimator : MonoBehaviour
{
    private Animator m_animator;
    //保存所有触发器列表
    private List<string> m_triggerNames;
    private AnimationTriggerManager m_triggerMgr;
    
    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_triggerNames = new List<string>();
        AnimatorControllerParameter[] parameters =  m_animator.parameters;
        for(int i=0; i<parameters.Length; i++)
        {
            if(parameters[i].type == AnimatorControllerParameterType.Trigger)
            {
                m_triggerNames.Add(parameters[i].name);
            }
        }
        m_triggerMgr = new AnimationTriggerManager(m_animator, "isIdle");
        m_triggerMgr.Add("isMove", "isIdle");
        m_triggerMgr.Add("isAttack", "isIdle");
        m_triggerMgr.Add("isKick", "isAttack");
        m_triggerMgr.Add("isFrontKickR", "isKick");
        m_triggerMgr.Add("isFrontKickL", "isKick");
        m_triggerMgr.Add("isPunch", "isAttack");
        m_triggerMgr.Add("isPunchL", "isPunch");
        m_triggerMgr.Add("isPunchR", "isPunch");
        m_triggerMgr.Add("isPunchMoveL", "isPunch");
        m_triggerMgr.Add("isPunchMoveR", "isPunch");
         
    }

    public bool GetTriggerState(string tname)
    {
        AnimationTriggerNode node = m_triggerMgr.GetTrigger(tname);
        if(node != null)
        {
            return node.isActived;
        }
        return false;
    }

    void ResetTriggers()
    {
        if (m_animator == null)
            return;
        //foreach (string tname in m_triggerNames)
        //{
        //    m_animator.ResetTrigger(tname);
        //}
        m_triggerMgr.ResetTrigger();
    }

    public void Play(EAnimationType type, float speed)
    {
        switch(type)
        {
            case EAnimationType.Stand:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isIdle");
                }
                break;
            case EAnimationType.LPunch:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isPunchL");
                }
                break;
            case EAnimationType.RPunch:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isPunchR");
                }
                break;
            case EAnimationType.LPunchMove:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isPunchMoveL");
                }
                break;
            case EAnimationType.RPunchMove:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isPunchMoveR");
                }
                break;
            case EAnimationType.LKick:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isFrontKickL");
                }
                break;
            case EAnimationType.RKick:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isFrontKickR");
                }
                break;
            case EAnimationType.Move:
                {
                    ResetTriggers();
                    m_triggerMgr.OnTrigger("isMove");
                }
                break;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.loop == false)
        {
             
            if (stateInfo.normalizedTime >= 1.0)
            {
                Debug.Log(stateInfo.normalizedTime);
                m_triggerMgr.OnTrigger("isIdle");
            }
        }
    } 
}
