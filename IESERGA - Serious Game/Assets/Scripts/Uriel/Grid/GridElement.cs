using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{

    //game object to be highlighted when selected
    [SerializeField] public GameObject highlight;

    //game object to be used for grid spacing
    [SerializeField] public GameObject gridSquare;

    [SerializeField] private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    public void toggleSelected(bool bVal){
        isSelected = bVal;
        highlight.SetActive(isSelected);
    }

    public bool getSelected(){

        return this.isSelected;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
