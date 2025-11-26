using UnityEngine;
using UnityEngine.InputSystem;

public class Cue : MonoBehaviour
{
    Rigidbody rb;

    Vector3 desiredVelocity;
    Transform lastStableTransform;


    public float moveSpeed = 15.0f;

    public InputActionReference move;
    public InputActionReference stop;

    bool isStopPressed;

    [SerializeField] private GameObject cueBall;
    //[SerializeField] private GameObject cueHolder;

    [Header("Cue Input")]
    [SerializeField] private float rotationSpeed = 25.0f;


    void Start()
    {
        // Get Rigidbody
        rb = GetComponent<Rigidbody>();

        // Test CueBall
        cueBall = GameObject.FindGameObjectWithTag("Cue Ball");

        // Get cue holder transform
        //cueHolder = this.transform.parent.gameObject;

        PositionCue();
    }

    void Update()
    {
        // Get input
        desiredVelocity = move.action.ReadValue<Vector2>();

        // If player is attempting to rotate 
        if (desiredVelocity.x != 0 && desiredVelocity.y == 0)
        {
            UpdateRotation(desiredVelocity.x, rotationSpeed);
        }

        Debug.DrawRay(this.transform.position, GetDirection(cueBall.transform.position) * 100f, Color.red);
    }

    private void FixedUpdate()
    {
        // Set velocity to 0 if there is no input
        if (desiredVelocity.y == 0)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        rb.AddForce(GetDirection(cueBall.transform.position, true) * desiredVelocity.y * moveSpeed);
    }

    // Rotate cue holder around the current CueBall
    private void UpdateRotation(float input, float speedMulti)
    {
        // Rotate cue around the current CueBall (cue ball) 
        this.transform.RotateAround(cueBall.transform.position, Vector3.up, -input * speedMulti * Time.deltaTime);
    }

    public void PositionCue()
    {
        // Reset rotation
        this.transform.rotation = new Quaternion(0.0f, 0.0f, 0.70711f, 0.70711f);

        // Calc desired position, and set cue position
        Vector3 desiredPosition = new Vector3(cueBall.transform.position.x + 1.5f, cueBall.transform.position.y, cueBall.transform.position.z);
        this.transform.position = desiredPosition;
    }

    // Return the direction between the cue and a given position
    private Vector3 GetDirection(Vector3 targPos, bool normalized = false)
    {
        // If normalize is toggled, return normalized direction vector
        if (normalized)
        {
            Vector3 tempPos = targPos - this.transform.position;
            return tempPos.normalized;
        }

        // Else return this.transform.position - targPos;
        return targPos - this.transform.position;
    }

    // Input action
    private void OnEnable()
    {
        stop.action.started += Stop;
    }

    private void Stop(InputAction.CallbackContext context)
    {
        PositionCue();
        //rb.linearVelocity = Vector3.zero;
    }



    // Collision
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cue Ball")
        {
            // Set cue velocity to zero upon contact with CueBall;
            rb.angularVelocity = Vector3.zero;
            rb.linearVelocity = Vector3.zero;
        }
    }
}
