using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject selectPrefab; // Assign your "Selectable" prefab here

    public int rows = 5;            // Number of rows in the grid
    public int columns = 5;         // Number of columns in the grid
    public float spacing = 1.5f;    // Space between each circle
    public Camera mainCamera;       // Reference to the main camera

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Assign main camera if not set
        }
        GenerateCenteredGrid();
    }

    private void GenerateCenteredGrid()
    {
        // Calculate grid size
        float gridWidth = (columns - 1) * spacing;
        float gridHeight = (rows - 1) * spacing;

        // Find the center of the screen in world space
        Vector3 screenCenter = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane + 10f)); // Offset Z for 2D

        // Calculate the bottom-left corner of the grid based on the center position
        Vector3 gridOrigin = new Vector3(
            screenCenter.x - gridWidth / 2,
            screenCenter.y - gridHeight / 2,
            0f
        );

        // Instantiate circles in each cell of the grid
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 cellPosition = new Vector2(gridOrigin.x + col * spacing, gridOrigin.y + row * spacing);
                GameObject select = Instantiate(selectPrefab, cellPosition, Quaternion.identity);
            }
        }
    }
}
