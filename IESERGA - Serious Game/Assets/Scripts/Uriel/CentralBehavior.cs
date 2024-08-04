using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralBehavior : MonoBehaviour
{
    public int nAnswer;

    [SerializeField]
    private GameObject door;
    
    // Start is called before the first frame update
    public void CheckForWin()
    {
        if(this.Verify()){

            door.SetActive(false);
        }

        else {
            Game_Manager.Instance.DeductChances();
        }
    }

    public bool Verify(){
        if(UI_Manager.Instance.intValue_GCF == nAnswer){
            return true;
        }
        
        else {
            return false;
        }
        
    }

    public void resetDoor(){

        door.SetActive(true);
    }
}
