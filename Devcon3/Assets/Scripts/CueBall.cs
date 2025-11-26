using UnityEngine;

public class CueBall : MonoBehaviour
{
    public Transform CueBallSpawn;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.transform.position = CueBallSpawn.position;
    }

    // Set cue ball to cue ball spawn point, reset velocity
    void CueBallToOrigin()
    {
        this.rb.linearVelocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
        this.transform.position = CueBallSpawn.position;
    }

    // If cue ball is pocketed
    void CueBallPocketed()
    {
        Debug.Log("Cue ball pocketed");
        CueBallToOrigin();
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pocket")
        {
            CueBallPocketed();
        }
    }
}
