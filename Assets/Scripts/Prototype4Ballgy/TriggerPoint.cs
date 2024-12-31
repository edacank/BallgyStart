using Prototype4.Ballgy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField]
    private int point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) {
            //Debug.Log($"Collision PLAYER {point}");
            // Point ...
            other.gameObject.GetComponent<Player>().Interact(point);
            if(point > 0) Destroy(gameObject, .5f);
        }
    }

}
