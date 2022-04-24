using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto5
{

    public class CharacterController : MonoBehaviour
    {
        Rigidbody rb;
        Camera viewCamera;
        Vector3 velocity;
        public float moveSpeed = 6;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            viewCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
            transform.LookAt(mousePos + Vector3.up * transform.position.y);
            velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}