using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCam : MonoBehaviour
{
    public CinemachineVirtualCamera[] Camera;
    CinemachineVirtualCamera my_cam;
    private void Start()
    {
        my_cam = GetComponent<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int x = 0; x < Camera.Length; x++)
            {
                Camera[x].Priority = 0;
                my_cam.Priority = 1;
            }
        }
    }
}
