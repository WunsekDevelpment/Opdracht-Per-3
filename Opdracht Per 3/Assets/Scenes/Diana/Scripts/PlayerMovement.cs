using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        public bool isMoving;
        public float horInput;
        public float verInput;
        public float baseSpeed;
        public float currentSpeed;
        public float sprint;
        Vector3 movedir;
        Rigidbody rb;
        public Transform orientation;

        [Header("Camera")]
        public Camera playerCamera;

        [Header("Ground&Drag")]
        public float groundDrag;
        public float airDrag;
        public float playerHeight;
        public LayerMask whatIsGround;
        public bool isGrounded;

        [Header("HeadBobbing")]
        public float bobbingSpeed;
        public float bobbingAmount;

        public float timer;
        public float defaultPosY;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;

            defaultPosY = playerCamera.transform.localPosition.y;
        }

        void Update()
        {
            //Ground Check
            isGrounded = Physics.Raycast(transform.position + new Vector3(0,0.1f,0), Vector3.down, whatIsGround);

            //Movement Input
            MyInput();

            //Handle Drag
            if(isGrounded)
                rb.drag = groundDrag;
            else
                rb.drag = airDrag;
        }
        void MyInput()
        {
            horInput = Input.GetAxisRaw("Horizontal");
            verInput = Input.GetAxisRaw("Vertical");

            if(horInput != 0 || verInput != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            if(isMoving)
            {
                MovePlayer();
                BobHead();
            }
        }

        void MovePlayer()
        {
            //MovePlayer
            movedir = orientation.forward * verInput + orientation.right * horInput;
            rb.AddForce(movedir.normalized * currentSpeed * 10f, ForceMode.Force);

            //PlayerSprint
            if(Input.GetKey(KeyCode.LeftControl))
            {
                currentSpeed = baseSpeed + sprint;
            }
            else
            {
                currentSpeed = baseSpeed;
            }
        }

        void BobHead()
        {
            if(isMoving && isGrounded)
            {
                timer += Time.deltaTime * bobbingSpeed;
                playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, playerCamera.transform.localPosition.z);
            }
            else
            {
                timer = 0;
                playerCamera.transform.localPosition = new Vector3(playerCamera.transform.localPosition.x, Mathf.Lerp(playerCamera.transform.localPosition.y, defaultPosY, Time.deltaTime * bobbingSpeed), playerCamera.transform.localPosition.z);
            }
        }
    }
}