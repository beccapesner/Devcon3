using Unity.VisualScripting;
using UnityEngine;

public class ObjectBall : MonoBehaviour
{
    public bool isStriped = false;
    public bool isEightBall = false;
    public TurnManager turnMan;
    public HomunculusController homMan;

    private void OnTriggerEnter(Collider other)
    {
        // If object ball enters a pocket
        if (other.gameObject.tag == "Pocket")
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "Homunculus")
                {
                    homMan.BallSunk();
                }
            }

            // Delineate eight ball
            if (isEightBall)
            {
                turnMan.eightballsunk();
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
