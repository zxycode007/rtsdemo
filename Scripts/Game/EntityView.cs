using UnityEngine;
using System.Collections;

public class EntityView : BaseObject
{
    private EntityAnimator m_animator;
    private int m_uid;

    public int uid
    {
        get
        {
            return m_uid;
        }
    }

    void Awake()
    {
        m_animator = gameObject.GetComponent<EntityAnimator>();
        m_uid = gameObject.GetHashCode();
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
