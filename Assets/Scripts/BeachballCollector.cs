using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachballCollector : MonoBehaviour
{
    public int count = 0;
    [SerializeField] private int winCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BEACHBALL"))
        {
            count++;
            Debug.Log(count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BEACHBALL"))
        {
            count--;
        }
    }
}
