using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int nChances = 3;
    public Dictionary<int, List<int>> data = new Dictionary<int, List<int>>();

    public void Reset(){
        ClearInventory();
        this.nChances = 3;
        UI_Manager.Instance.UpdateCounter(nChances);
    }

    private void ClearInventory(){

        foreach (int key in data.Keys)
        {
            data[key].Clear();
        }

        data.Clear();
    }

     public void DeductChances(){
       
        nChances -= 1;

        // Ensure chances don't go below 0
        if (nChances < 0)
        {
            nChances = 0;
        }

        // Update the UI to reflect the new number of chances
        UI_Manager.Instance.UpdateCounter(nChances);

        // Check if chances have run out
        if (nChances == 0)
        {
            Game_Manager.Instance.TriggerTimer();
        }

        Debug.Log($"Chances after deduction: {nChances}");
        
    }

}
