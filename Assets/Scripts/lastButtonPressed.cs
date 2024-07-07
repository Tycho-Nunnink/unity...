using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lastButtonPressed : MonoBehaviour
{

    public List<int> pressedButtons;

   void OnCollisionEnter(Collision collision)
    {
        if(collision != null) 
        {
            if (collision.gameObject.CompareTag("BUTTON"))
            {
                if (!pressedButtons.Contains(collision.gameObject.GetComponent<ButtonPlayerCheck>().buttonNumber))
                {
                    pressedButtons.Add(collision.gameObject.GetComponent<ButtonPlayerCheck>().buttonNumber);
                }
            }
        }
    }
}
