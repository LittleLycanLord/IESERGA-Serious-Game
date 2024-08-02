using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : Singleton<UI_Manager>
{
    public SC_FPSController player;
    public TMP_InputField user_input_field_1;
    public TMP_InputField user_input_field_2;

    public Canvas doorPrompt;
    
    public int intValue_1 = 0;

    public int intValue_2 = 0;

    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
        doorPrompt.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reset(){

        user_input_field_1.text = "Enter First Multiple";
        user_input_field_2.text = "Enter Second Multiple";

        intValue_1 = 0;
        intValue_2 = 0;
    }

    public void DisplayPrompt(){

        doorPrompt.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(player != null){
            player.canMove = false;
            player.canInteract = false;
        }

        else{
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
            player.canMove = false;
            player.canInteract = false;
        }
    }

    public void SetInput()
    {
        // Set the Text element to the value of the Input Field

        bool isInteger = int.TryParse(user_input_field_1.text, out intValue_1);
        bool isInteger2 = int.TryParse(user_input_field_2.text, out intValue_2);

        if(isInteger == true && isInteger2 == true){
            intValue_1 = int.Parse(user_input_field_1.text);
            intValue_2 = int.Parse(user_input_field_2.text);
        }

        else{
            intValue_1 = 0;
            intValue_2 = 0;
        }

        //function for opening the door.
        if(player.objectInRange != null){

            ConsoleBehavior consoleBehavior = player.objectInRange.GetComponent<ConsoleBehavior>();

            if(consoleBehavior != null){
                consoleBehavior.OpenDoor();
            }

        }

        this.ClosePrompt();
    }

    public void ClosePrompt(){

        this.Reset();
        doorPrompt.enabled = false;
        player.canMove = true;
        player.canInteract = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
