using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : GameBehaviour
{
    bool canKillEnemy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            canKillEnemy = true;
            _UI5.killEnemyUI.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && canKillEnemy == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(other.gameObject);
                canKillEnemy = false;
                _UI5.killEnemyUI.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            canKillEnemy = false;
            _UI5.killEnemyUI.SetActive(false);
        }
    }

}
