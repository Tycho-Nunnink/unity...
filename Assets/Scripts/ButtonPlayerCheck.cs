using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlayerCheck : MonoBehaviour
{

    private bool isPressed = false;
    public int buttonNumber;

    private GameObject player;

    private GameObject[] allButtons;

    private Vector3 originalPosition;



    // Start is called before the first frame update
    void Start()
    {
        allButtons = GameObject.FindGameObjectsWithTag("BUTTON");
        originalPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    void Update()
    {
        
    }

    void UnPress()
    {
        isPressed = false;
        GetComponent<Renderer>().material.color = Color.red;
        transform.position = originalPosition;
    }
    void Press()
    {
        isPressed = true;
        GetComponent<Renderer>().material.color = Color.green;
        transform.position = new Vector3(originalPosition.x, originalPosition.y- 0.1844818f, originalPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("PLAYER"))
            {
                player = collision.gameObject;

                for (int i = 0; i < player.GetComponent<lastButtonPressed>().pressedButtons.Count; i++)
                {
                    if(i == player.GetComponent<lastButtonPressed>().pressedButtons[i])
                    {
                        Press();
                    }
                    else
                    {
                        foreach(var button in allButtons)
                        {
                            button.GetComponent<ButtonPlayerCheck>().UnPress();
                            player.GetComponent<lastButtonPressed>().pressedButtons.Clear();
                        }
                    }
                }
                
            }
        }
    }
}
