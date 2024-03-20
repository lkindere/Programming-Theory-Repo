using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float mouseSpeed = 0.01f;


    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;

        transform.position += verticalInput * speed * Time.deltaTime  * forward;
        transform.position += horizontalInput * speed * Time.deltaTime * right;

        float horizontalMouse = Input.GetAxis("Mouse X");
        float verticalMouse = Input.GetAxis("Mouse Y");

        cam.transform.RotateAround(transform.position, Vector3.up, horizontalMouse);
        cam.transform.Rotate(Vector3.left, verticalMouse);
    }
}
