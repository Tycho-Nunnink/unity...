using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachballSpawner : MonoBehaviour
{
    [SerializeField] private GameObject beachBall;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(beachBall, new Vector3(Random.Range(-14, 14), transform.position.y, Random.Range(-14, 14)), Quaternion.identity);
        }
    }
}
