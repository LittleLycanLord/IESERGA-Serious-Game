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

  


    // Start is called before the first frame update
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();

        if(player != null){

            playerLocation =  player.gameObject.transform.position;

        }

        nNumberofChances = 3;
    }

    public void ResetAllVariables() {

       player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();

        if(player != null){

            playerLocation =  player.gameObject.transform.position;

        }

        nNumberofChances = 3;
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



    }
}