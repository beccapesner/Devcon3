using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GelCubeController : MonoBehaviour
{
    public List<GameObject> ballsInPlay = new();
    public bool isActive = false;
    public bool hasSpawned = false;
    public bool hasRB = false;
    public bool hasHit = false;
    public AudioSource winLossPlayer;
    public AudioClip slimeGurgling;

    public float eatingTimer;
    public bool isEating = false;

    public GameObject target;

    public GameObject engulfedBall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ballsInPlay.RemoveAll(item => item == null);

        if (isEating)
        {
            eatingTimer += Time.deltaTime;
            if (eatingTimer >= 6)
            {
                Destroy(engulfedBall);

                if (eatingTimer >= 10)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (!hasSpawned && isActive)
        {
            hasSpawned = true;
            //Spawn homunculus on the table


            target = ballsInPlay[Random.Range(0, ballsInPlay.Count)];
            transform.position = target.transform.position + new Vector3(0.01f, 1f, 0.01f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("GELATINOUS CUBE SPAWNED");
        }
        if (hasSpawned)
        { if (!hasRB)
            {
                Rigidbody rb = gameObject.AddComponent<Rigidbody>();
                hasRB = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Object Balls") && !isEating)
        {

            isEating = true;
            transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

            engulfedBall = collision.gameObject;

            Rigidbody rb = engulfedBall.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }

            engulfedBall.transform.SetParent(transform);

            engulfedBall.transform.localPosition = Vector3.zero;

            winLossPlayer.PlayOneShot(slimeGurgling);
        }
    }
    public void BallSunk()
    {
        transform.SetParent(null);
        if (!isActive) isActive = true;
    }
}
