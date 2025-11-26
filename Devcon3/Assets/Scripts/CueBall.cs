using UnityEngine;

public class CueBall : MonoBehaviour
{
    public Transform CueBallSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = CueBallSpawn.position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
