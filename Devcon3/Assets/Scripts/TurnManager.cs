using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    public TextMeshProUGUI playerTurnText;
    public DisplayRack displayRack;

    public bool isP1sTurn;
    public bool p2BallsSunk;
    public bool p1BallsSunk;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isP1sTurn && playerTurnText.text != "Player 1's Turn")
        {
            playerTurnText.text = "Player 1's Turn";
        }
        if (!isP1sTurn && playerTurnText.text != "Player 2's Turn")
        {
            playerTurnText.text = "Player 2's Turn";
        }
    }
}
