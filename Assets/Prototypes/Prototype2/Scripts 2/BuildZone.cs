using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Proto2
{
    public class BuildZone : GameBehaviour
    {
        public Transform buildZone;
        public bool isBuilding;
        private Renderer renderer;
        public Material StandardColour;
        public Material HoverColour;

       

        private void Start()
        {
            
            renderer = gameObject.GetComponent<Renderer>();
            renderer.material = StandardColour;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                if (isBuilding)
                {
                    BuildTree();
                }
                    
        }
        public void BuildTree()
        {

            if (_PS.seeds >= 10)
            {
                if (_SH.treeToBuild == null)
                    return;

                Instantiate(_SH.treeToBuild, gameObject.transform.position, gameObject.transform.rotation);

                _PS.seeds -= 10;
                _UI2.UpdateSeedAmount(_PS.seeds);
                renderer.material = StandardColour;
                gameObject.GetComponent<Collider>().enabled = false;
                isBuilding = false;

            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isBuilding = true;
                renderer.material = HoverColour;

            }                
        }
        private void OnTriggerExit(Collider other)
        {
            isBuilding = false;
            renderer.material = StandardColour;
        }
    }
}