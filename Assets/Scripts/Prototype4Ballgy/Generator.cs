
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4.Ballgy
{
    public class Generator : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("0: Ball Neg , 1: Ball Pos")]
        private List<GameObject> ballPrefabs = new List<GameObject>();

        [SerializeField]
        private float initialForce;


        // Start is called before the first frame update
        void Start()
        {
            var delay = Random.Range(2, 5);
            var period = Random.Range(0, 5);
            InvokeRepeating("Generate", delay, period); // gecikme,  periyod
        }

        private void Generate()
        {
            var randIndex = Random.Range(0, ballPrefabs.Count);
            var ballObj = Instantiate(ballPrefabs[randIndex], transform.position, Quaternion.identity);
            ballObj.GetComponent<Rigidbody>().AddForce(new Vector3 (0, 0, -initialForce));

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}