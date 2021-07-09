using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizer : MonoBehaviour
{
    void Start() 
    {

    }
    void OnTriggerEnter(Collider other) 
    {
        if (gameObject.tag == "Back" || gameObject.tag == "Front")
        {
           other.gameObject.GetComponent<MeshRenderer>().enabled=false;

           if (other.gameObject.tag == "Decorative")
           {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Stop(); 
           }
           
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (gameObject.tag == "Front")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled=true;
            
            if (other.gameObject.tag == "Decorative")
           {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play(); 
           }
        }
    }
}
