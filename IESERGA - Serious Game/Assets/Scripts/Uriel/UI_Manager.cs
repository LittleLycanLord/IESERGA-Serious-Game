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
    public TMP_InputField gcf_input_field; 

    public TMP_Text primeText;

    public Canvas doorPrompt;

    public Canvas exitPrompt;

    public Canvas winPrompt;

    public Canvas losePrompt;
    
    public int intValue_1 = 0;

    public int intValue_2 = 0;

    public int intValue_GCF = 0;

    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SC_FPSController>();
        doorPrompt.enabled = false;
        exitPrompt.enabled = false;
        winPrompt.enabled = false;
        losePrompt.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Reset(){

        user_input_field_1.text = "Enter First Multiple";
        user_input_field_2.text = "Enter Second Multiple";

        intValue_1 = 0;
        intValue_2 = 0;

        intValue_GCF = 0;
        gcf_input_field.text = "Enter GCF";
        primeText.text = "[MISSING ALL, FIND MORE DATA PACKETS]";
    }

    public void DisplayPrompt(){

        this.Reset();
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

    public void DisplayGCFPrompt(){

        this.Reset();
        exitPrompt.enabled = true;
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

        if(Game_Manager.Instance.ids != null){

            int i = 0;
            int maximumSize = Game_Manager.Instance.ids.Count;
            primeText.text = " ";

            foreach (int id in Game_Manager.Instance.ids){

                primeText.text += id.ToString();
                i++;

                if(i < maximumSize){
                    primeText.text += " x ";
                }
            }

        }

    }

    public void DisplayWin(){

        this.Reset();
        winPrompt.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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

    public void DisplayDefeat(){

        this.Reset();
        losePrompt.enabled = true;
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

        this.ClosePrompt(doorPrompt);
    }

    public void SetGCFInput(){

        bool isInteger = int.TryParse(gcf_input_field.text, out intValue_GCF);

        if(isInteger == true){
            intValue_GCF = int.Parse(gcf_input_field.text);
        }

        else {
            intValue_GCF = 0;
        }

        if(player.objectInRange != null){

            CentralBehavior centralBehavior = player.objectInRange.GetComponent<CentralBehavior>();

            if(centralBehavior != null){
                centralBehavior.CheckForWin();
            }

        }

        this.ClosePrompt(exitPrompt);
    }

    public void ClosePrompt(Canvas canvas){

        canvas.enabled = false;
        player.canMove = true;
        player.canInteract = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        this.Reset();

    }


}
