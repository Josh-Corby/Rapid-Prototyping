using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Proto1
{


    public class PlayerController : GameBehaviour
    {
        //player variables and refernces
        public bool hasPowerup;
        public GameObject powerupIndicator;
        private GameObject focalPoint;
        private Rigidbody playerRb;
        public float speed = 5.0f;
        public GameObject player;

        //tween variables and references
        public float tweenTime = 0.5f;
        public Ease moveEase;


        // private float powerupStrength = 15.0f;
        private void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        /// <summary>
        /// This function is the player input and movement function
        /// it also checks for if the player has reached the height at which they should die
        /// </summary>
        private void Update()
        {
            float fowardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(focalPoint.transform.forward * speed * fowardInput);

            float sideInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(focalPoint.transform.right * speed * sideInput);
            powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);

           
            if (transform.position.y < -1)
            {
                _GM1.ToggleGameOver();
            }

            if (transform.position.y < 1)
            {

                if (Input.GetKeyDown("space"))
                {
                    Vector3 jump = new Vector3(0.0f, 600f, 0.0f);
                    GetComponent<Rigidbody>().AddForce(jump);
                    ChangeScale();
                }
            }
        }

        /// <summary>
        /// powerup function
        /// checks if player collides with a powerup object
        /// if so then the player enters the powerup state and the powerup object is destroyed
        /// powerup indicator is activated
        /// </summary>
        /// <param name="other"></param>
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

        /// <summary>
        /// countdown timer for the powerup
        /// </summary>
        /// <returns> powerup state to false </returns>
        IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(10);
            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
        }
        /// <summary>
        /// if the player is in the powerup state and collides with an enemy, the enemy is destroyed
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
            {

                Destroy(collision.gameObject);
                //Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                //Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

                //Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
                //enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
        }

        /// <summary>
        /// tween function that changes player scale
        /// </summary>
        void ChangeScale()
        {
            player.transform.DOPunchScale(Vector3.one * 1, tweenTime).OnComplete(() => player.transform.DOPunchScale(Vector3.one, tweenTime / 2));
        }
    }
}