using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField] private GameObject remotePartBackground;
    [SerializeField] private GameObject cinemachineCamera;

    void Update()
    {
        remotePartBackground.transform.position
            = new Vector3(cinemachineCamera.transform.position.x,
            remotePartBackground.transform.position.y);
    }
}
