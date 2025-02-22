using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{

    [SerializeField] public int width, height;
    [SerializeField] public Tile tilePrefab;
    [SerializeField] GameObject Grid;
    [SerializeField] GameObject GridReplacamentPlace;
    private bool colourSwitch = true;
    private int tileOrder = 0;
    public GameObject Water;
    public GameObject FinishBox;
    

    private void Start()
    {
        GenerateGrid();
        changeColourSwitch();
    }
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++ )
            {

                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                changeColourSwitch();
                spawnedTile.transform.parent = Grid.transform;
                spawnedTile.name = $"Tile {tileOrder}";
                PlaceWaterBasedOnLevel();

            }
        }
        Grid.transform.position = GridReplacamentPlace.transform.position;
    }
    void changeColourSwitch()
    {
       if (colourSwitch)
        {
            tilePrefab.renderer.color = tilePrefab.colour1;
            colourSwitch = false;
        }
       else
        {
            tilePrefab.renderer.color = tilePrefab.colour2;
            colourSwitch = true;
        }
    }

    void PlaceWaterBasedOnLevel()
    {
        tileOrder = tileOrder + 1;

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (tileOrder == 8)
            {
                Debug.Log("sgmkljfd;anbkjsgnmjbjlksdmgf");

                var spawnedWater = Instantiate(Water);
                spawnedWater.transform.position = GameObject.Find("Tile 7").transform.position;
                spawnedWater.transform.parent = Grid.transform;


            }
        }
    }

}
