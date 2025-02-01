using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxSelect : MonoBehaviour
{
    public RectTransform selectionBox; // Reference to a UI element to visually display the selection box

    public LayerMask selectLayerMask;
    private Vector2 startPos;
    private Vector2 endPos;
    private List<GameObject> selectedObjects = new List<GameObject>();

    //components
    [SerializeField]
    private Camera cam;

    void Start(){

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Start selecting
        {
            selectedObjects = new List<GameObject>();
            TrySelect();
            startPos = Input.mousePosition;
          
           
            //selectedObjects = new List<GameObject>();
        }

        if (Input.GetMouseButton(0)) // While holding the mouse button
        {    
            UpdateSelectionBox(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0)) // Release the selection
        {
           selectedObjects = new List<GameObject>();
           ReleaseSelectionBox();
        }
    }

    void UpdateSelectionBox(Vector2 curMousePos)
    {
        if(!selectionBox.gameObject.activeInHierarchy)
            selectionBox.gameObject.SetActive(true);
        float width = curMousePos.x - startPos.x;
        float height = curMousePos.y - startPos.y;
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        selectionBox.anchoredPosition = startPos + new Vector2(width / 2, height / 2);
    
    }

    void TrySelect(){
        RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if(hit){
            if(hit.collider.gameObject.CompareTag("Selectable")){

               
                if(!hit.collider.gameObject.GetComponent<GridElement>().getSelected())
                    hit.collider.gameObject.GetComponent<GridElement>().toggleSelected(true);
                else
                    hit.collider.gameObject.GetComponent<GridElement>().toggleSelected(false);
                selectedObjects.Add(hit.collider.gameObject);
            }
        }
    }

    void ReleaseSelectionBox ()
    {
        selectionBox.gameObject.SetActive(false);
        
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        foreach (GameObject selectable in GameObject.FindGameObjectsWithTag("Selectable"))
        {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(selectable.transform.position);

                if(screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
                {
                    selectedObjects.Add(selectable);
                    if(!selectable.gameObject.GetComponent<GridElement>().getSelected())
                        selectable.GetComponent<GridElement>().toggleSelected(true);
                    // Optionally, add feedback for selected circles
                    Debug.Log($"Selected {selectable.name}");
                }
        }
    }
}

