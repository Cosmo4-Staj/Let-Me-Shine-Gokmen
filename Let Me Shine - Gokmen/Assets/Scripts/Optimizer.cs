using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimizer : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    void Start() 
    {

    }
    void OnTriggerEnter(Collider other) 
    {
        if (gameObject.tag == "Back" || gameObject.tag == "Front")
        {
           other.gameObject.GetComponent<MeshRenderer>().enabled=false;
           other.gameObject.GetComponentInChildren<MeshRenderer>().enabled=false;

           if (other.gameObject.tag == "Decorative" || other.gameObject.tag == "Bridge")
           {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Stop(); 
           }

           if (other.gameObject.tag == "Bridge")
           {
                other.gameObject.GetComponentInChildren<MeshRenderer>().enabled=false;
           }
           
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if (gameObject.tag == "Front")
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled=true;
            other.gameObject.GetComponentInChildren<MeshRenderer>().enabled=true;
            
            if (other.gameObject.tag == "Decorative" || other.gameObject.tag == "Bridge")
           {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play(); 
           }
        }
    }
}
