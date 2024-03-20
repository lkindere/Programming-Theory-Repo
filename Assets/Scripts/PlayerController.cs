using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float rotateSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        if (Input.GetKey(KeyCode.Q))
            cam.transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            cam.transform.RotateAround(transform.position, Vector3.up, -rotateSpeed * Time.deltaTime);
    }
}
