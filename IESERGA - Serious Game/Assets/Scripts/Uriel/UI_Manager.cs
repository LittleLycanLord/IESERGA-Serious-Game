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

    private string stringValue = "0";
    int intValue_1 = 0;

    int intValue_2 = 0;

    bool success = false;

    void Start(){
        doorPrompt.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
    }
    public void Reset(){

        user_input_field_1.text = "Enter First Multiple";
        user_input_field_2.text = "Enter Second Multiple";

        intValue_1 = 0;
        intValue_2 = 0;
    }

    public void DisplayPrompt(){

        doorPrompt.enabled = true;

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
    public void SetInputOne()
    {
        // Set the Text element to the value of the Input Field

        success = int.TryParse(user_input_field_1.text, out intValue_1);

        if(success == true)
            intValue_1 = int.Parse(user_input_field_1.text);
        
        else
            intValue_1 = 0;
    }

    public void ClosePrompt(){

        //this.Reset();
        doorPrompt.enabled = false;
        player.canMove = true;
        player.canInteract = true;

    }
}
