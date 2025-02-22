using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public Color colour1, colour2;
    [SerializeField] public SpriteRenderer renderer;
    [SerializeField] private GameObject HoverOverHighlightPositive;
    [SerializeField] private GameObject HoverOverHighlightNegative;
    [SerializeField] public bool objectCanBePlaced;
    [SerializeField] public bool objectCantBePlaced;


    public Controller controller;
    public Powder powder;
    public bool tileIsFull;
    public GameObject CurrentPickedPowderObject;
    public GridManager gridManager;




    void Start()
    {
        tileIsFull = false;
        objectCanBePlaced = false;
        objectCantBePlaced = false;
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();

        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();
        
        
        


    }

    private void Update()
    {
        disableColliderDependingOnCollision();
    }

    void disableColliderDependingOnCollision()
    {
        if (controller.objectIsPickedUp == false && controller.transform.position == gameObject.transform.position)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = true;

        }
    }
    public void callControllerGameObkect()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();

    }


    private void OnMouseOver()
    {
        CurrentPickedPowderObject = gridManager.ClickedPowderObject;
        if (gameObject.transform.position == GameObject.FindWithTag("Powder").transform.position || gameObject.transform.position == GameObject.FindWithTag("Controller").transform.position)
        {
            tileIsFull = true;
        }
        else
        {
            tileIsFull = false;

        }

        if (objectCanBePlaced && controller.objectIsPickedUp&& !objectCantBePlaced)
            {
                HoverOverHighlightPositive.SetActive(true);
            }
            if (!objectCanBePlaced && controller.objectIsPickedUp)
            {
                HoverOverHighlightNegative.SetActive(true);
            }
        


        
    } 
    private void OnMouseExit()
    {
        
        
        HoverOverHighlightPositive.SetActive(false);
        HoverOverHighlightNegative.SetActive(false);


    }
    private void OnMouseDown()
    {
        
        if (controller.objectIsPickedUp && objectCanBePlaced && !tileIsFull)
        {
            Debug.Log("Clicked after controller");

            controller.ControllerTransformChangeTo = gameObject;
            controller.changePositionToSelectedTile();
            objectCanBePlaced = false;

        }

        if (gridManager.powderObjectIsPickedUp && objectCanBePlaced && !tileIsFull)
        {
            Debug.Log("Clicked after Powder");

            gridManager.PowderControllerTransformChangeTo = gameObject;
            gridManager.changePowderObjectPositionToSelectedTile();
            objectCanBePlaced = false;
        }
        //Debug.Log(gameObject.name);

    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.name == "Controller")
        {
            
            objectCanBePlaced = true;
        

        } 
        if (other.tag == "Powder")
        {           
            objectCanBePlaced = true;
           
        

        }
       

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Controller" && other.gameObject.tag == "Powder")
        { 
            objectCanBePlaced = true;
            HoverOverHighlightPositive.SetActive(false);

        }

    }

}
