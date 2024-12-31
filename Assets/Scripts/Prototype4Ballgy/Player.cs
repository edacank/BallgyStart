using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4.Ballgy
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject gameManager;

        [SerializeField]
        private float speed = 10f;
        private Rigidbody rb;

        public void Interact(int point)
        {
            gameManager.GetComponent<GameManager>().SendPoint(point);
        }

        // Start is called before the first frame update
        void Start()
        {
            // Get the Rigidbody component attached to this GameObject
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Get input from the user (W, A, S, D keys)
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Create a vector for movement direction
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Apply force to the Rigidbody for movement
            rb.AddForce(movement * speed);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}