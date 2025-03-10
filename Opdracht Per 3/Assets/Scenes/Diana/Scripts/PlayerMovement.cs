using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        bool isMoving;
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

        [Header("GroundCheck")]
        public float groundDrag;
        public float airDrag;
        public float playerHeight;
        public LayerMask whatIsGround;
        bool isGrounded;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }

        void FixedUpdate()
        {
            //Movement Input
            MyInput();

            //Handle Drag
            if(isGrounded)
                rb.drag = groundDrag;
            else
                rb.drag = airDrag;
            
            //Ground Check
            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        }
        void MyInput()
        {
            horInput = Input.GetAxisRaw("Horizontal");
            verInput = Input.GetAxisRaw("Vertical");

            if(horInput != 0)
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
    }
}