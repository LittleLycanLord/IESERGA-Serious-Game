using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//GameManager is responsible for holding variables separate from the player, or to be maintained while inside a level.
public class Game_Manager : Singleton<Game_Manager>
{   
    public SC_FPSController player;
    
    //playerLocation is determined by the player's position at the start of the level.
    Vector3 playerLocation = Vector3.zero; 


    // Start is called before the first frame update
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();

        if(player != null){

            playerLocation =  player.transform.position;

        }
    }

    public void ResetAllVariables() {


      player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();

        if(player != null){

            player.transform.position = playerLocation;
        }

     PlayerData playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();

        if(playerData != null){

            playerData.Reset();
        }


        GameObject[] consoles;
        consoles = GameObject.FindGameObjectsWithTag("Console");

        foreach (GameObject console in consoles){
            ConsoleBehavior behavior = console.GetComponent<ConsoleBehavior>();
            behavior.Reset();

        }


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

        Debug.Log("Variables reset.");
         // Get the currently active scene


        UI_Manager.Instance.Initialize();
        
    }

    public void TriggerTimer(){

        TimerScript timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();

        if(timer != null){
            timer.ActivateTimer();
        }

    }

    public void addToInventory(int row, int id){

        PlayerData player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();

        if (!player.data.ContainsKey(row))
        {
            player.data[row] = new List<int>();
        }

        player.data[row].Add(id);

    }

    public void TriggerWin(){

        UI_Manager.Instance.DisplayWin();

    }

    public void TriggerDefeat(){

        UI_Manager.Instance.DisplayDefeat();

    }

    public void QuitGame(){
        Application.Quit();
    }
}