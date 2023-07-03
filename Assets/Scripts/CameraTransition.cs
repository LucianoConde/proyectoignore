using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraTransition : MonoBehaviour
{
    [SerializeField] float transitionTime;
    [SerializeField] CinemachineVirtualCamera cam1, cam2;
    void Update()
    {
        transitionTime += Time.deltaTime;
        if (transitionTime > 1)
        {
            cam1.enabled = false;
            cam2.enabled = true;
        }
    }
}
