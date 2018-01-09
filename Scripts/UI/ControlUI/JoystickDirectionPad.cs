using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class JoystickDirectionPad : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler
{

    public RectTransform m_controllerRect;
    public float m_speed;
    public GameEventContext m_EvtCtx;
    //public CharacterController m_controller;


    private RectTransform m_rectTransform;
    private Transform m_target;
    private float m_nRadius;
    private float m_nSqrRadius;
    private float m_nPower;
    private bool m_bMousePressed;


    void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_nRadius = m_controllerRect.rect.width / 2 - 20;
        m_nSqrRadius = m_nRadius * m_nRadius;
        m_nPower = 100;
        m_bMousePressed = false;
        m_EvtCtx = new GameEventContext();
    }

    private void Move(float x, float y)
    {
        //Vector3 moveTo = new Vector3(x, 0, y);
        ////变换自身的朝向到世界坐标系中
        //Vector3 dir = m_target.TransformDirection(moveTo);
        //dir.Normalize();
        //m_controller.Move(dir * m_speed * Time.deltaTime);
    }


    void UpdatePosition(Vector3 holderPos)
    {
        Vector3 dir = holderPos.normalized;
        float len = holderPos.sqrMagnitude;
        if (len > m_nSqrRadius)
        {
            len = m_nRadius;
            holderPos = dir * len;

        }
        if(EntityManager.instance.curEntity != null)
        {
            Transform et = EntityManager.instance.curEntity;
            Animator animator = et.gameObject.GetComponentInChildren<Animator>();
            animator.SetFloat("curDirX", dir.x);
            animator.SetFloat("curDirY", dir.y);
            animator.SetFloat("curDirZ", dir.z);
            animator.SetFloat("speed", 5);
            EntityAnimator eanimator = et.gameObject.GetComponentInChildren<EntityAnimator>();
            eanimator.Play(EAnimationType.Move, 1.0f);
        }
        //DataBuffer buf = new DataBuffer();
        //buf.WriteFloat(dir.x);
        //buf.WriteFloat(dir.y);
        //buf.WriteFloat(dir.z);
        //GameEvtArg arg = new GameEvtArg(buf);
        //m_EvtCtx.FireEvent(this, GameEventType.EVT_INPUT_JOYSTICK_DIR_CHANGED, arg);
        m_rectTransform.anchoredPosition = holderPos;
    }
    void Update()
    {

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector3 pos = m_rectTransform.anchoredPosition;
            pos.x += x * m_nPower;
            pos.y += y * m_nPower;
            UpdatePosition(pos);

        }

        else if (m_bMousePressed)
        {
            Vector3 pos = m_rectTransform.anchoredPosition;
            UpdatePosition(pos);
        }
        else if (!m_bMousePressed)
        {
            m_rectTransform.anchoredPosition = Vector3.zero;
            if (EntityManager.instance.curEntity != null)
            {
                Transform et = EntityManager.instance.curEntity;
                //EntityAnimator animator = et.gameObject.GetComponentInChildren<EntityAnimator>();
                //if (animator.GetTriggerState("isIdle") == false)
                //{
                //    animator.Play(EAnimationType.Stand, 1.0f);

                //    //animator.SetTrigger("isIdle");
                //}
            }
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 vec = Vector3.zero;

        Vector3 pos = m_rectTransform.anchoredPosition;
        Vector2 localPos = m_rectTransform.localPosition;
        Vector2 delta = eventData.position - localPos;

        pos.x += delta.x;
        pos.y += delta.y;

        Vector3 dir = pos.normalized;
        float len = pos.sqrMagnitude;
        if (len > m_nSqrRadius)
        {
            len = m_nRadius;
            pos = dir * len;
        }
        m_rectTransform.anchoredPosition = pos;

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        m_bMousePressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!m_bMousePressed)
        {
            m_rectTransform.anchoredPosition = Vector3.zero;
        }
        m_bMousePressed = false;
    }



    // Use this for initialization
    void Start()
    {

    }

}
