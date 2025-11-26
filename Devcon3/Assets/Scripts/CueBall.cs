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

    void CueBallToOrigin()
    {
        this.transform.position = CueBallSpawn.position;
    }

    void CueBallPocketed()
    {
        Debug.Log("Cue ball pocketed");
        CueBallToOrigin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pocket")
        {
            CueBallPocketed();
        }

        if (other.gameObject.tag == "Billiard")
        {
            rb.linearVelocity = -rb.linearVelocity * 0.5f;
        }
    }
}
