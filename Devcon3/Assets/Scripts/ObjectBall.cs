using UnityEngine;

public class ObjectBall : MonoBehaviour
{
    public bool isStriped = false;
    public bool isEightBall = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pocket")
        {
            if (isEightBall)
            {
                GameManager.instance.pocketedSolids++;
                Debug.Log("Eight ball pocketed");
                Destroy(this.gameObject);
            }

            if (isStriped)
            {
                if (!DisplayRack.instance.firstStripPocketed)
                {
                    DisplayRack.instance.firstStripPocketed = true;
                    Destroy(this.gameObject);
                    return;
                }

                GameManager.instance.pocketedStripes++;
                Debug.Log("Striped ball pocketed");
            }
            else
            {
                if (!DisplayRack.instance.firstSolidPocketed)
                {
                    DisplayRack.instance.firstSolidPocketed = true;
                    Destroy(this.gameObject);
                    return;
                }
                    

                GameManager.instance.pocketedSolids++;
                Debug.Log("Solid ball pocketed");
            }

            Destroy(this.gameObject);
        }
    }
}
