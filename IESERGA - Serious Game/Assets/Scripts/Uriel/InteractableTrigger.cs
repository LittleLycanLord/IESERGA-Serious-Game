using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
   //Public id to refer to what kind of keycard it is
   public int id = 0;

   [SerializeField]
   private GameObject keycard;

   private bool isPickedUp = false;
   public void OnHit(){

      if(isPickedUp == false){
         Game_Manager.Instance.addToInventory(id);
         isPickedUp = true;
         keycard.SetActive(false);
      }

   }

   public void Reset(){

      this.gameObject.SetActive(true);
      keycard.SetActive(true);
      isPickedUp = false;
   }
    
}
