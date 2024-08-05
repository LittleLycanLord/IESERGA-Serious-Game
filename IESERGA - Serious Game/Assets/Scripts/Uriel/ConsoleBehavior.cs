using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class ConsoleBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject assigned_Door;

    //number value that helps assign the console's number to be deciphered.
    public int nNumberVal = 0;

    private bool hasDeducted = false;

    public bool isVariantRoom = false; // by default false

    [SerializeField]
    private int nVariantNumber = 0;

    [SerializeField]
    private GameObject roomVariant1 = null;

    [SerializeField]
    private GameObject roomVariant2 = null;


    public void OpenDoor(){

        if(Verify(UI_Manager.Instance.intValue_1, UI_Manager.Instance.intValue_2))
        {
            if(isVariantRoom == true){
                VariantLoad(UI_Manager.Instance.intValue_1, UI_Manager.Instance.intValue_2);
            }
            this.assigned_Door.SetActive(false);
        }

        else {
            hasDeducted = true;
            PlayerData player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
            player.DeductChances();
            hasDeducted = false;
        }
    }

    public void VariantLoad(int nMultiple1, int nMultiple2){
       if(CheckPrime(nMultiple1) == false){

            if(nVariantNumber != nMultiple1){

                if(roomVariant1 != null){
                    roomVariant1.SetActive(false);
                    roomVariant2.SetActive(true);
                }

            }

       }
       
       else if(CheckPrime(nMultiple2) == false){

            if(nVariantNumber != nMultiple2){

                if(roomVariant1 != null){
                    roomVariant1.SetActive(false);
                    roomVariant2.SetActive(true);
                }

            }
       }
    }

    private bool CheckPrime(int number){

        bool isPrime = true;

        for (int i = 2; i <= Mathf.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                isPrime = false;
            }
        }

        return isPrime;
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

        if(isVariantRoom == true){
            roomVariant1.SetActive(true);
            roomVariant2.SetActive(false);
        }

    }
}
