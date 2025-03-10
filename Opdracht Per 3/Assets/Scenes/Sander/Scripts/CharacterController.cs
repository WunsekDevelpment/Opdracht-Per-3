using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 moveDir;
    public Vector3 playerRotate;
    public Vector3 camRotate;
    public float speed;
    public float sensitivity;
    public Transform cam;
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");

        moveDir.z = Input.GetAxis("Vertical");

        transform.Translate(moveDir * speed * Time.deltaTime);

        playerRotate.y = Input.GetAxis("Mouse X");

        camRotate.x = Input.GetAxis("Mouse Y");

        transform.Rotate(playerRotate * sensitivity * Time.deltaTime);

        cam.Rotate(-camRotate * sensitivity * Time.deltaTime);
    }
}
