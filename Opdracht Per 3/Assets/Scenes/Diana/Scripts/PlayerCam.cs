using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerCam : MonoBehaviour
    {
        [Header("Camera")]
        public float sensY;
        public float sensX;
        float xrotation;
        float yrotation;

        public Transform Orientation;
        
        [SerializeField]
        private bool rotationClamp = true;
        public float rotationClampValue = 90f;
        void Start()
        {
            //Lock and hide the cursor.
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
    
        public void Update()
        {
            //Get x & y input for the rotation of the camera.
            float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            //add x input to yrotation and subtract y from x rotation.
            yrotation += mousex;
            xrotation -= mousey;

            //To prevent the camera from rotating more than 90 degrees either way (up/down), clamp the x rotation from -90f to 90f.
            RotationClamp();
        
            //To rotate the camera and orientation of the player..
            //Rotate the camera along both axes
            transform.rotation = Quaternion.Euler(xrotation, yrotation, 0);
            //and rotate the player along the y axis.
            Orientation.rotation = Quaternion.Euler(0, yrotation, 0);
        }

        private void RotationClamp()
        {
            if(rotationClamp == true)
            {
                xrotation = Mathf.Clamp(xrotation, -rotationClampValue, rotationClampValue);
            }
        }
    }
}
