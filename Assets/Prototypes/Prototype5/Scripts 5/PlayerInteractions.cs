using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : GameBehaviour
{
    bool canInteract = false;
    private GameObject interaction;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interaction != null)
            {
               Destroy(interaction);
                _UI5.InteractionTextToggle(false);

                if(interaction.tag == "Intel")
                {
                    _GM5.intelCollected += 1;
                    _UI5.IntelCollectedUI(_GM5.intelCollected);
                }
            }
           
            canInteract = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            interaction = other.gameObject;
            canInteract = true;
            _UI5.KillEnemyUI();
            _UI5.InteractionTextToggle(true);
        }

        if(other.CompareTag("Intel"))
        {
            interaction = other.gameObject;
            canInteract = true;
            
            _UI5.InteractionTextToggle(true);
            _UI5.IntelUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            canInteract = false;
            _UI5.InteractionTextToggle(false);
            interaction = null;
        }

        if (other.CompareTag("Intel"))
        {
            canInteract = false;
            _UI5.InteractionTextToggle(false);
            interaction = null;
        }
    }

}
