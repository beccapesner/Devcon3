using UnityEngine;

public class DisplayRack : MonoBehaviour
{
    public int pocketedStripes = 0;
    public int pocketedSolids = 0;

    public GameObject[] stripes;
    public GameObject[] solids;

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
        for (int i = 0; i < pocketedStripes; i++)
        {
            if (!stripes[i].activeSelf)
                stripes[i].SetActive(true);
        }

        for (int i = 0; i < pocketedSolids; i++)
        {
            if (!solids[i].activeSelf)
                solids[i].SetActive(true);
        }
    }
}
