using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variustwo : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            other.SendMessage("VariusDamage");
            transform.gameObject.SendMessage("DestroyVarius");
        }
    }


    
}
