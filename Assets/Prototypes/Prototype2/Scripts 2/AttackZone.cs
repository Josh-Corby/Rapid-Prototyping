using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto2
{
    public class AttackZone : GameBehaviour
    {
        private void Start()
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                
                other.GetComponent<Enemy>().TakeDamage(_P.damage);
                //Debug.Log("Enemy Hit");
            }
        }
    
        public void Attack()
        {
            StartCoroutine(AttackZoneToggle());
        }
        public IEnumerator AttackZoneToggle()
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Collider>().enabled = true;
            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}