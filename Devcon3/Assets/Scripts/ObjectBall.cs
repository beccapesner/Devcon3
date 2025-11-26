using Unity.VisualScripting;
using UnityEngine;

public class ObjectBall : MonoBehaviour
{
    public bool isStriped = false;
    public bool isEightBall = false;


    private void OnTriggerEnter(Collider other)
    {
        // If object ball enters a pocket
        if (other.gameObject.tag == "Pocket")
        {
            // Delineate eight ball
            if (isEightBall)
            {
                GameManager.instance.pocketedSolids++;
                Debug.Log("Eight ball pocketed");
                Destroy(this.gameObject);
            }

            // Delineate stripe and solids
            if (isStriped)
            {
                // If this is the first pocketed ball, enable the first ball rendered for display rack
                if (!DisplayRack.instance.firstStripPocketed)
                {
                    DisplayRack.instance.firstStripPocketed = true;
                    Destroy(this.gameObject);
                    return;
                }

                GameManager.instance.pocketedStripes++;
                Debug.Log("Striped ball pocketed"); // Debug Message
            }
            else
            {
                // If this is the first pocketed ball, enable the first ball rendered for display rack
                if (!DisplayRack.instance.firstSolidPocketed)
                {
                    DisplayRack.instance.firstSolidPocketed = true;
                    Destroy(this.gameObject);
                    return;
                }
                    
                GameManager.instance.pocketedSolids++;
                Debug.Log("Solid ball pocketed"); // Debug Message
            }

            Destroy(this.gameObject);
        }
    }
}
