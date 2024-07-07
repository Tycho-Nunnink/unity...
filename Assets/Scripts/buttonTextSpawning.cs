using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class buttonTextSpawning : MonoBehaviour
{

    private GameObject[] allButtons;
    // Start is called before the first frame update
    void Start()
    {
        allButtons = GameObject.FindGameObjectsWithTag("BUTTON");
        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].GetComponentInChildren<TextMeshPro>().text = allButtons[i].GetComponent<ButtonPlayerCheck>().buttonNumber.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
