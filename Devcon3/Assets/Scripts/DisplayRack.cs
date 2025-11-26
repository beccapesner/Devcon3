using UnityEngine;

public class DisplayRack : MonoBehaviour
{
    public static DisplayRack instance;

    public int pocketedStripes = -1;
    public int pocketedSolids = -1;

    public bool firstStripPocketed = false;
    public bool firstSolidPocketed = false;

    public GameObject[] stripes;
    public GameObject[] solids;

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
        for (int i = 0; i < stripes.Length; i++)
        {
            stripes[i].SetActive(false);
            solids[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleStripes();
        HandleSolids();
    }

    void HandleStripes()
    {
        if (!firstStripPocketed)
            return;

        pocketedStripes = GameManager.instance.pocketedStripes;
        
        for (int i = 0; i < stripes.Length; i++)
        {
            if (i <= pocketedStripes)
            {
                if (!stripes[i].activeSelf)
                    stripes[i].SetActive(true);
            }
            else
            {
                if (stripes[i].activeSelf)
                    stripes[i].SetActive(false);
            }
        }
    }

    void HandleSolids()
    {
        if (!firstSolidPocketed)
            return;

        pocketedSolids = GameManager.instance.pocketedSolids;

        for (int i = 0; i < solids.Length; i++)
        {
            if (i <= pocketedSolids)
            {
                if (!solids[i].activeSelf)
                    solids[i].SetActive(true);
            }
            else
            {
                if (solids[i].activeSelf)
                    solids[i].SetActive(false);
            }
        }
    }
}
