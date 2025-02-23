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
    public bool mouseIsOnTile;
    public bool controllerIsCollideing;

    public GameObject CurrentPickedPowderObject;
    public GridManager gridManager;
    public Collider2D objectCollider2D;




    void Start()
    {
        mouseIsOnTile = false;
        controllerIsCollideing = false;

        tileIsFull = false;
        objectCanBePlaced = false;
        objectCantBePlaced = false;
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();

        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();





    }

    private void Update()
    {
        disableColliderDependingOnCollision2();
        // StartCoroutine(timerForPowderPositionCheck());
    }
    IEnumerator timerForPowderPositionCheck()
    {
        yield return new WaitForSeconds(1);
        forceTilesToBeAvailableForPowder();

        if (gameObject.transform.position == GameObject.FindWithTag("Powder").transform.position)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;


        }
    }

    void forceTilesToBeAvailableForPowder()
    {
        if (gameObject.transform.position != GameObject.FindWithTag("Powder").transform.position && controllerIsCollideing == true)
        {
            objectCanBePlaced = true;
            Debug.Log("Amina Koyim");
        }
    }
    void disableColliderDependingOnCollision2()
    {
        /* if (controller.objectIsPickedUp == false && controller.transform.position == gameObject.transform.position)
         {
             gameObject.GetComponent<Collider2D>().enabled = false;
         }
         else
         {
             gameObject.GetComponent<Collider2D>().enabled = true;

         }
         if (gridManager.ClickedPowderObject != null)
         {
             if (gridManager.ClickedPowderObject.transform.position == gameObject.transform.position && gridManager.powderObjectIsPickedUp == false)
             {
                 gameObject.GetComponent<Collider2D>().enabled = false;

             }

         }*/
        if ( gameObject.transform.position != GameObject.FindWithTag("Controller").transform.position || gameObject.transform.position != GameObject.FindWithTag("Powder").transform.position)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
            //Debug.Log("collider enabled");

        }
       
       

        if ( gameObject.transform.position == GameObject.FindWithTag("Controller").transform.position || gameObject.transform.position == GameObject.FindWithTag("Powder").transform.position)
        {
            gameObject.GetComponent<Collider2D>().enabled = false;

        }
        
    }
    public void callControllerGameObkect()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();

    }


    private void OnMouseOver()
    {
        
        HoverOverHighlightNegative.SetActive(true);

        mouseIsOnTile = true;
        CurrentPickedPowderObject = gridManager.ClickedPowderObject;
        if (gameObject.transform.position == GameObject.FindWithTag("Controller").transform.position || gameObject.transform.position == GameObject.FindWithTag("Powder").transform.position)
        {
            tileIsFull = true;
        }
        if (gameObject.transform.position != GameObject.FindWithTag("Controller").transform.position || gameObject.transform.position != GameObject.FindWithTag("Powder").transform.position)
        {
            tileIsFull = false;
        }
    }
    private void OnMouseExit()
    {
        mouseIsOnTile = false;

        HoverOverHighlightNegative.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (mouseIsOnTile == false && gameObject.transform.position != GameObject.FindWithTag("Powder").transform.position)
        {
            gameObject.GetComponent<Collider2D>().enabled = true;

        }
        //gameObject.GetComponent<Collider2D>().enabled = false;

        if (controller.objectIsPickedUp && !tileIsFull)
        {
            objectCollider2D.enabled = true;
            Debug.Log("Clicked after controller");
            

            controller.ControllerTransformChangeTo = gameObject;
            controller.changePositionToSelectedTile();
           


            //objectCanBePlaced = false;

        }

        if (gridManager.powderObjectIsPickedUp && objectCanBePlaced && !tileIsFull && gridManager.powderObjectCanBeMoved)
        {
            objectCollider2D.enabled = true;

            Debug.Log("Clicked after Powder");

            gridManager.PowderControllerTransformChangeTo = gameObject;
            gridManager.changePowderObjectPositionToSelectedTile();
            gameObject.GetComponent<Collider2D>().enabled = true;

            //objectCanBePlaced = false;
        }
        //Debug.Log(gameObject.name);

    }



    private void OnTriggerExit2D(Collider2D other)
    {
        /*if (other.gameObject.name == "Controller" && other.gameObject.tag != "Powder" || other.gameObject.tag == "Powder"&& other.gameObject.name != "Controller")
        { 
            objectCanBePlaced = false;
            HoverOverHighlightPositive.SetActive(false);
            
        }*/

        /*      if (other.gameObject.name == "Controller")
              {
                  objectCanBePlaced = false;
                  controllerIsCollideing = false;

              }
              if (other.gameObject.name == "Powder")
              {
                  objectCanBePlaced = true;

              }*/
        if (other.tag == "Collider" || other.tag == "Powder")
        {
            objectCanBePlaced = true;

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        /*            if (other.gameObject.name == "Controller" && gameObject.transform.position != GameObject.FindWithTag("Powder").transform.position)
                    {
                    controllerIsCollideing = true;
                    objectCanBePlaced = true;

                    }
            }
            void ChangeTilesToCanBeClicked()
            {
                        objectCanBePlaced = true;

            }*/
        if (other.tag == "Collider" || other.tag == "Powder")
        {
            objectCanBePlaced = true;

        }
    }
}
