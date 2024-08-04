using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ConsoleBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject assigned_Door;

    //number value that helps assign the console's number to be deciphered.
    public int nNumberVal = 0;

    private bool hasDeducted = false;

    public void OpenDoor(){

        if(Verify(UI_Manager.Instance.intValue_1, UI_Manager.Instance.intValue_2))
        {
            this.assigned_Door.SetActive(false);
        }

        else {
            hasDeducted = true;
            PlayerData player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
            player.DeductChances();
            hasDeducted = false;
        }
    }

    private bool Verify(int nMultiple1, int nMultiple2){

        if(nMultiple1 > 1 && nMultiple2 > 1){

            if(nNumberVal / nMultiple1 == nMultiple2 || nNumberVal / nMultiple2 == nMultiple1){

                if(nMultiple1 != nNumberVal && nMultiple2 != nNumberVal){
                    
                    return true;

                }

            }
        }

        Debug.Log("Verification failed. Mark as mistake.");
        return false;
        
    }

    public void Reset(){

        this.assigned_Door.SetActive(true);

    }
}
