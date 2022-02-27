using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{


    public class PlayerController : GameBehaviour
    {
        public bool hasPowerup;
        public GameObject powerupIndicator;
        private GameObject focalPoint;
        private Rigidbody playerRb;
        public float speed = 5.0f;


        private float powerupStrength = 15.0f;
        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        private void Update()
        {
            float fowardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);

            float sideInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(focalPoint.transform.right * speed * sideInput);
            powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);

           
            if (transform.position.y < -10)
            {
                _GO.ToggleGameOver();
            }

            if (transform.position.y < 0)
            {

                if (Input.GetKeyDown("space"))
                {
                    Vector3 jump = new Vector3(0.0f, 400f, 0.0f);
                    GetComponent<Rigidbody>().AddForce(jump);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                hasPowerup = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
                powerupIndicator.gameObject.SetActive(true);
            }
        }

        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(9);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {

                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

                Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
                enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }
    }
}