using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    CinemachineFreeLook cam;
    private float shakeTimer;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cam = GetComponent<CinemachineFreeLook>(); 
    }

   public void CamShake(float intensity, float time)
    {
     var cam1 = cam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
     var cam2 = cam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
     var cam3 = cam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
        cam1.m_AmplitudeGain = intensity;
        cam2.m_AmplitudeGain = intensity;
        cam3.m_AmplitudeGain = intensity;

        shakeTimer = time;

    }

    private void Update()
    {
       if(shakeTimer > 0) 
        {
          shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                var cam1 = cam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                var cam2 = cam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                var cam3 = cam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cam1.m_AmplitudeGain = 0f;
                cam2.m_AmplitudeGain = 0f;
                cam3.m_AmplitudeGain = 0f;
            }
        }
     
    }
}
