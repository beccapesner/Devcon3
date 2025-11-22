using UnityEngine;
using UnityEngine.InputSystem;

public class Cue : MonoBehaviour
{
    Rigidbody rb;

    Vector3 desiredVelocity;
    float moveSpeed = 15.0f;

    public InputActionReference move;
    public InputActionReference stop;

    bool isStopPressed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        desiredVelocity = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (desiredVelocity.x == 0)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        rb.linearVelocity += new Vector3(desiredVelocity.x * moveSpeed * Time.deltaTime, 0.0f, 0.0f);
    }

    private void OnEnable()
    {
        stop.action.started += Stop;
    }

    private void Stop(InputAction.CallbackContext context)
    {
        rb.linearVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Billiard")
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
