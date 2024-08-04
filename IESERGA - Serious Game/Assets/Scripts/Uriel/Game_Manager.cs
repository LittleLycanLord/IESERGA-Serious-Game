using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager is responsible for holding variables separate from the player, or to be maintained while inside a level.
public class Game_Manager : Singleton<Game_Manager>
{   
    public SC_FPSController player;
    
    //playerLocation is determined by the player's position at the start of the level.
    Vector3 playerLocation = Vector3.zero;

    public int nNumberofChances = 3;

    public List<int> ids = new List<int>();

  


    // Start is called before the first frame update
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();

        if(player != null){

            playerLocation =  player.transform.position;

        }
        nNumberofChances = 3;
    }

    public void ResetAllVariables() {

       player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
       Debug.Log("Variables reset.");

        if(player != null){

            player.transform.position = playerLocation;

        }

        GameObject[] consoles;
        consoles = GameObject.FindGameObjectsWithTag("Console");

        foreach (GameObject console in consoles){
            ConsoleBehavior behavior = console.GetComponent<ConsoleBehavior>();
            behavior.Reset();

        }

            nNumberofChances = 3;
        
        GameObject[] interactables;
        interactables = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject interactable in interactables){
            InteractableTrigger behavior = interactable.GetComponent<InteractableTrigger>();
            behavior.Reset();

        }
        

        if(UI_Manager.Instance.losePrompt.enabled == true){
            UI_Manager.Instance.ClosePrompt(UI_Manager.Instance.losePrompt);
        }

        if(UI_Manager.Instance.winPrompt.enabled == true){
            UI_Manager.Instance.ClosePrompt(UI_Manager.Instance.winPrompt);
            CentralBehavior centralBehavior = GameObject.FindGameObjectWithTag("Central Console").GetComponent<CentralBehavior>();
            centralBehavior.resetDoor();
        }
    }

    public void DeductChances(){

        if(nNumberofChances > 0){

            nNumberofChances -= 1;

            if(nNumberofChances == 0){

                TriggerTimer();

            }
        }

    }

    public void TriggerTimer(){

        TimerScript timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();

        if(timer != null){
            timer.ActivateTimer();
        }

    }

    public void addToInventory(int id){

        if(id != 0){
            ids.Add(id);
        }

    }

    public void TriggerWin(){

        UI_Manager.Instance.DisplayWin();

    }

    public void TriggerDefeat(){

        UI_Manager.Instance.DisplayDefeat();

    }
}