using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : GameBehaviour
{
    bool canKillEnemy = false;
    private GameObject enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (enemy != null)
            {
               Destroy(enemy);
            }
           
            canKillEnemy = false;
            _UI5.killEnemyUI.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemy = other.gameObject;
            canKillEnemy = true;
            _UI5.killEnemyUI.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            canKillEnemy = false;
            _UI5.killEnemyUI.SetActive(false);
            enemy = null;
        }
    }

}
