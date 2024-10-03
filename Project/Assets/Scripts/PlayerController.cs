using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera camera;


    [Header("Configurations")]
    [SerializeField] public float walkSpeed;
    [SerializeField] public float runSpeed;
    [SerializeField] public float jumpSpeed;


    [Header("Runtime")]
    [SerializeField] Vector3 newVelocity;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool isJumping = false;


    // Start is called before the first frame update
    void Start() {
        //  Hide and lock the mouse cursor
        // RenderSettings.ambientIntensity = 0f; // Will make it dark
		// RenderSettings.reflectionIntensity = 0f; // will make it dark
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update() {
        // Horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 1f);   // Adjust the multiplier for different rotation speed

        newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed; 

        if (isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
                newVelocity.y = jumpSpeed;
                isJumping = true;
            }
        }
        rb.velocity = transform.TransformDirection(newVelocity);
    }

    void FixedUpdate() {
        //  Shoot a ray of 1 unit towards the ground
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f)) {
            isGrounded = true;
        }
        else isGrounded = false;
    }

    void LateUpdate() {
        // Vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;   //  Edit the multiplier to adjust the rotate speed
        e.x = RestrictAngle(e.x, -85f, 85f);    //  This is clamped to 85 degrees. You may edit this.
        head.eulerAngles = e;
    }


    //  This will be called constantly
    void OnCollisionStay(Collision col) {
        if (Vector3.Dot(col.GetContact(0).normal, Vector3.up) <= .6f)
            return;

        isGrounded = true;
        isJumping = false;
    }


    void OnCollisionExit(Collision col) {
        isGrounded = false;
    }


    //  A helper function
    //  Clamp the vertical head rotation (prevent bending backwards)
    public static float RestrictAngle(float angle, float angleMin, float angleMax) {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
}