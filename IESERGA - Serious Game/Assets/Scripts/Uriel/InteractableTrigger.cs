using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    SC_FPSController player;
    UI_Manager UI_Controller;
    // Start is called before the first frame update

    void Start(){
        Debug.Log("Interactable trigger instantiated.");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
    }

    void OnTriggerEnter(Collider other){
        
        Debug.Log("Object interactable in range.");

        if(other.CompareTag("Interactable") == true){
            Debug.Log("Object interactable in range.");
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
            player.objectInRange = other.gameObject;
            player.canInteract = true;
        }
    }

    void OnTriggerExit(Collider other){
         if(other.CompareTag("Interactable") == true){
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
            player.canInteract = false;
        }
    }
}
