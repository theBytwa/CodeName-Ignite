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
    public GameObject Powder;
    public GameObject Controller1StartTile;
    public Controller controller;
    public GameObject ClickedPowderObject;
    public bool powderObjectIsPickedUp;
    public GameObject PowderControllerTransformChangeTo;
    public bool powderObjectCanBeMoved;
    public bool test;
    public bool isClicked;

    public IEnumerator isClickedSwitchTimer()
    {
        isClicked = true;
        yield return new WaitForEndOfFrame();
        isClicked = false;

    }
    public void playIsClickedSwitchTimer()
    {
        StartCoroutine(isClickedSwitchTimer());
    }
    private void Update()
    {
        
    }

    private void Start()
    {
        test = false;
        powderObjectIsPickedUp = false;
        StartCoroutine(PlaceControllerBasedOnLevel());
        StartCoroutine(PlacePowderBasedOnLevel());
        

        GenerateGrid();
        changeColourSwitch();
    }
    void GenerateGrid()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene") 
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
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
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
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
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
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
    }

   
    public void changePowderObjectPositionToSelectedTile()
    {
        ClickedPowderObject.transform.position = PowderControllerTransformChangeTo.transform.position;
        ClickedPowderObject.GetComponent<Powder>().powderObjectIsPickedUp = false;

        PowderControllerTransformChangeTo = null;
        powderObjectIsPickedUp = false;
        
        //test = false;

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
       // Debug.Log(tileOrder);

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (tileOrder == 8)
            {
                

                var spawnedWater = Instantiate(Water);
                spawnedWater.transform.position = GameObject.Find("Tile 7").transform.position;
                spawnedWater.transform.parent = Grid.transform;
               
            }
        }
    }

    IEnumerator PlacePowderBasedOnLevel()
    {
        yield return new WaitForEndOfFrame();

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            /*if (tileOrder == 15)
            {*/
                var spawnedPowder = Instantiate(Powder);
                spawnedPowder.transform.position = GameObject.Find("Tile 14").transform.position;
                
                

           /* }*/
        }
    }

            IEnumerator PlaceControllerBasedOnLevel() 
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();

        yield return new WaitForEndOfFrame();
        SetStarterTilesBasedOnLevel();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        { 
            if (tileOrder == 25)
            {
                controller.ControllerTransformChangeTo = Controller1StartTile;

                controller.changePositionToSelectedTile();
            }
        }

    }


    void SetStarterTilesBasedOnLevel()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Controller1StartTile = GameObject.Find("Tile 21");
        }
    }

    


}
