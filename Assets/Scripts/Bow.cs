using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    public float minArrowSpeed = 10;
    public float maxArrowSpeed = 50;
    public float maxChargeTime = 2f; 
    public float cooldownTime = 2f; 
    public Camera playerCamera; 

    private float chargeTime = 0;
    private bool isCharging = false;
    private float lastShotTime = -Mathf.Infinity;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Time.time >= lastShotTime + cooldownTime)
            {
                isCharging = true;
                chargeTime = 0;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isCharging)
            {
                chargeTime += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            if (isCharging)
            {
                isCharging = false;
                FireArrow();
                lastShotTime = Time.time;
            }
        }
    }

    void FireArrow()
    {
        var arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);

        float arrowSpeed = Mathf.Lerp(minArrowSpeed, maxArrowSpeed, chargeTime / maxChargeTime);

        Vector3 direction = playerCamera.transform.forward;

        arrow.GetComponent<Rigidbody>().velocity = direction * arrowSpeed;

        chargeTime = 0;
    }
}
