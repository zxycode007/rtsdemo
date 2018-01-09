using UnityEngine;
using System.Collections;

public enum ECameraModeType
{
    ThirdPersonCamera,
    FreedomCamera,
    DefaultCamera
}

public class CameraController : MonoBehaviour
{
    CameraMode m_cameraMode;

    public CameraMode cameraMode
    {
        get
        {
            return m_cameraMode;
        }
    }

    public void SwitchCameraMode(ECameraModeType type)
    {
        if(m_cameraMode != null)
            m_cameraMode.OnSwitchMode();
        switch(type)
        {
            case ECameraModeType.DefaultCamera:
                {
                    m_cameraMode = new CameraMode();
                }
                break;
            case ECameraModeType.ThirdPersonCamera:
                {
                    m_cameraMode = new ThirdPersonCameraMode();
                }
                break;
        }
        if(m_cameraMode != null)
        {
            m_cameraMode.transform = transform;
            m_cameraMode.Init();
        }

    }

    public static CameraController instance;

    void Awake()
    {
        instance = this;
        SwitchCameraMode(ECameraModeType.ThirdPersonCamera);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(m_cameraMode != null)
        {
            m_cameraMode.Update();
        }
        
    }
}
