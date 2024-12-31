using Prototype4.Ballgy;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    //public int maxCount;
    [SerializeField]
    private GameManager gameManager; 

    public void StartCounter(int maxCount)
    {
        StartCoroutine(Counter(maxCount));
    }

    IEnumerator Counter(int maxCount)
    {
        int count = 0;
        while (true) {
            if (count == maxCount) {
                break;
            }
            yield return new WaitForSeconds(1f);
            //Debug.Log($"{count}");
            gameManager.Tick(maxCount-count);
            count++;
            // Counter?
        }
    }
}
