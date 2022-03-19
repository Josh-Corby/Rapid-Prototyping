using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Proto2
{
    public class Enemy : GameBehaviour
    {
        public GameObject target;
        public GameObject hitEffect;

        public GameObject HealthBar;
        public Slider slider;

        private Camera camera;

        public float speed;
        public float currentHealth;
        public float maxHealth = 10;
        public int damage;

        public Transform partToRotate;
        public float turnspeed = 10f;

        //private float tweenTime = 0.05f;
        //private Tween tween;

        private void Start()
        {
            
            camera = FindObjectOfType<Camera>();
            SetMaxHealth(maxHealth);

            currentHealth = maxHealth;
            target = GameObject.Find("WayPoint");
        }

        private void Update()
        {
            HealthBar.transform.LookAt(camera.transform.position);
            transform.LookAt(target.transform.position);
            Vector3 dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }

        public void TakeDamage(int _damage)
        {
            GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            //StartScaleAnimation();

            currentHealth -= _damage;
            SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                _SM2.DestroyEnemy(this.gameObject);
                _PS.seeds += 1;
                _UI2.UpdateSeedAmount(_PS.seeds);
            }       
            
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MainTree"))
            {
                other.GetComponent<MainTree>().TakeDamage(damage);
                Debug.Log("Tree Hit!");
                _SM2.DestroyEnemy(this.gameObject);
            }
        }

        //HealthBar Functions
        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
        public void SetHealth(float health)
        {
            slider.value = health;
        }

        //private void StartScaleAnimation()
        //{
        //    Vector3 local = transform.localScale;
        //    tween = gameObject.transform.DOPunchScale(local / 5, tweenTime, 0, 1f).SetAutoKill(false);
        //}
    }
}