using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;

    void Update()
    {
        transform.forward = -DirectionToCamera();
    }

    Vector3 DirectionToCamera() {
        Vector3 pos = transform.position;
        Vector3 targetPos = cam.transform.position;

        pos.y = 0.0f;
        targetPos.y = 0.0f;

        return (pos - targetPos).normalized;
    }
}
