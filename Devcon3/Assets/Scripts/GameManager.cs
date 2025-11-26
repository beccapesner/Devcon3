using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject cueStick;
    public List<GameObject> objectBalls;
    public GameObject cueBall;
    public DisplayRack displayRack;

    public int pocketedStripes = 0;
    public int pocketedSolids = 0;

    bool cueStickVisable = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectBalls = GameObject.FindGameObjectsWithTag("Billiard").ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCue();


    }

    private void HandleCue()
    {
        cueStick.SetActive(cueStickVisable);

        if (cueBall.GetComponent<Rigidbody>().linearVelocity == Vector3.zero)
        {
            
            cueStickVisable = true;
        }
        else

        {
            cueStick.GetComponent<Cue>().PositionCue();
            cueStickVisable = false;
        }
    }
}
