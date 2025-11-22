using UnityEngine;

public class Billiard : MonoBehaviour
{

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cue")
        {
            CueHit(collision.transform); //.gameObject.transform);
        }
    }

    private void CueHit(Transform cueTransform)
    {
        Vector3 dir = this.transform.position - cueTransform.position;
        rb.AddForce(dir * 100f, ForceMode.Impulse);


    }
}
