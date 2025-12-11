    using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public class HomunculusController : MonoBehaviour
    {
        public List<GameObject> ballsInPlay = new();
        public bool isActive = false;
        public bool hasSpawned = false;
        public bool hasReachedBall = false;
        public bool hasPickedUpBall = false;
        public Transform homunculusSpawn;

        public GameObject target;
        void Start()
        {
        } 

        void Update()
        {
            ballsInPlay.RemoveAll(item => item == null);


            if (!hasSpawned && isActive)
            {
                hasSpawned = true;
                //Spawn homunculus on the table
                transform.position = homunculusSpawn.position;
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                Debug.Log("HOMUNCULUS SPAWNED");
                target = ballsInPlay[Random.Range(0, ballsInPlay.Count)];
            }

            if (hasSpawned)
            {

            if (hasReachedBall)
            {
                if (!hasPickedUpBall)
                {
                    Rigidbody rb = target.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.useGravity = false;
                        rb.constraints = RigidbodyConstraints.FreezeAll;
                    }
                    target.transform.SetParent(transform);    
                    target.transform.localPosition = new Vector3(0.01f, 5.5f, 0.01f);
                    hasPickedUpBall = true;
                    transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                }
                else if (hasPickedUpBall)
                {
                    transform.position = Vector3.MoveTowards(
                                    transform.position,
                                    homunculusSpawn.position,
                                    0.3f * Time.deltaTime);

                    if (Vector3.Distance(transform.position, homunculusSpawn.position) < 0.2f)
                    {
                        target.transform.SetParent(null);
                        Rigidbody rb = target.GetComponent<Rigidbody>();
                        if (rb != null)
                        {
                            rb.useGravity = true;
                            rb.constraints = RigidbodyConstraints.None;
                        }
                        Destroy(gameObject);
                    }
                }
            }

            else if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
            {
                hasReachedBall = true;
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                                    transform.position,
                                    target.transform.position,
                                    0.3f * Time.deltaTime);
            }
                
            }

        }

        public void BallSunk()
        {
            transform.SetParent(null);
            if (!isActive) isActive = true;
        }
    }
