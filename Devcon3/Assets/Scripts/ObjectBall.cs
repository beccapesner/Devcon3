using UnityEngine;

public class ObjectBall : MonoBehaviour
{
    public bool isStriped = false;
    public bool isEightBall = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pocket")
        {
            if (isEightBall)
            {
                Debug.Log("Eight ball pocketed");
                Destroy(this.gameObject);
            }

            if (isStriped)
            {
                Debug.Log("Striped ball pocketed");
            }
            else
            {
                Debug.Log("Solid ball pocketed");
            }

            Destroy(this.gameObject);
        }
    }
}
