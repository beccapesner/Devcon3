using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    public bool hasWon;
    public float winTimer;

    public TextMeshProUGUI playerTurnText;
    public TextMeshProUGUI winText;
    public DisplayRack displayRack;
    public Image winImage;

    public AudioSource winLossPlayer;
    public AudioClip winClip;

    public bool isSolidTurn;
    public bool solidBallsSunk;
    public bool stripeBallsSunk;


    void Start()
    {
        winImage.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }


    //Find somewhere to put this gameMan.isP1sTurn = !gameMan.isP1sTurn; //switches to other players turn when ballstops


    // Update is called once per frame
    void Update()
    {
        if (hasWon)
        {
            winTimer += Time.deltaTime;
            if (winTimer >= 10f)
            {
            }
        }


        if (isSolidTurn && playerTurnText.text != "Solid's Turn")
        {
            playerTurnText.text = "Solid's Turn";
        }
        if (!isSolidTurn && playerTurnText.text != "Stripe's Turn")
        {
            playerTurnText.text = "Stripe's Turn";
        }
        
        if (!solidBallsSunk && displayRack.pocketedSolids >= 7)
        {
            solidBallsSunk = true;
        }
        if (!stripeBallsSunk && displayRack.pocketedSolids >= 7)
        {
            stripeBallsSunk = true;
        }

    }

    public void eightballsunk()
    {
        if (isSolidTurn && solidBallsSunk) 
        {
            solidsWin();
        }
        else if (isSolidTurn && !solidBallsSunk)
        {
            stripesWin();
        }
        else if (!isSolidTurn && stripeBallsSunk)
        {
            stripesWin();
        }
        else if (!isSolidTurn && !stripeBallsSunk)
        {
            solidsWin();
        }

    }

    public void solidsWin()
    {
        hasWon = true;
        winLossPlayer.PlayOneShot(winClip);
        winImage.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        winText.text = "SOLIDS!!";

    }

    public void stripesWin()
    {
        hasWon = true;
        winLossPlayer.PlayOneShot(winClip);
        winImage.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        winText.text = "STRIPES!!";

    }
}
