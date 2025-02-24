using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    /*[SerializeField] public Collider2D UP;
    [SerializeField] public Collider2D Down;
    [SerializeField] public Collider2D Right;
    [SerializeField] public Collider2D Left;*/
    [SerializeField] Tile tile;
    public GameObject ControllerTransformChangeTo;
    private Rigidbody2D rb;
    public GridManager gridManager;
    public bool powderObjectCanComeNear;





    public bool objectIsPickedUp = false;
    //private bool objectIsPutDown = true;
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.AddComponent<Rigidbody2D>();
        powderObjectCanComeNear = false;

        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        //tile = GameObject.FindGameObjectsWithTag("Tile").


    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
    private void OnMouseDown()
    {
        if (!objectIsPickedUp)
        {
            objectIsPickedUp = true;
            //objectIsPutDown = false;
            gridManager.powderObjectIsPickedUp = false;
            //gridManager.ClickedPowderObject = null;
            //gridManager.test = true;
            gridManager.playIsClickedSwitchTimer();
            
            //tile.GetComponent<Collider2D>().enabled = true;

        }      
    }
    public void changePositionToSelectedTile()
    {
        gameObject.transform.position = ControllerTransformChangeTo.transform.position;
        ControllerTransformChangeTo = null;
        objectIsPickedUp = false;
        gridManager.test = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Powder")
        {
            gridManager.powderObjectCanBeMoved = true;
            other.gameObject.GetComponent<Collider2D>().enabled = true;
            powderObjectCanComeNear = true;


        }
        if (other.gameObject.tag == "Tile")
        {
            other.GetComponent<Tile>().objectCanBePlaced = true;
            other.GetComponent<Tile>().objectCollider2D.enabled = true;
            Debug.Log("collision");
            Debug.Log(other);
            other.GetComponent<Tile>().powderCanBePlacedOn = true;
<<<<<<< HEAD
            //other.GetComponent<Tile>().powderObjectLastBoolean = true;

=======
>>>>>>> parent of 285af82 (safety push)

        }



    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Powder")
        {
            gridManager.powderObjectCanBeMoved = true;
            powderObjectCanComeNear = false;

        }
        if (other.gameObject.tag == "Tile" && other.gameObject.tag != "Powder")
        {
            other.GetComponent<Tile>().objectCanBePlaced = true;
            other.GetComponent<Tile>().objectCollider2D.enabled = true;
<<<<<<< HEAD

           // other.GetComponent<Tile>().powderObjectLastBoolean = false;


=======
>>>>>>> parent of 285af82 (safety push)
            //other.GetComponent<Tile>().powderCanBePlacedOn = false;



        }
<<<<<<< HEAD
        if (other.gameObject.tag == "Tile")
        {
            other.GetComponent<Tile>().ttttttttt = false;


        }
=======
>>>>>>> parent of 285af82 (safety push)
    }
  
    public void FindAllPowdersAndChangeTheBlocks()
    {
        //GameObject.FindWithTag("Powder").GetComponent<Powder>().testBool = true;
        gridManager.powderObjectCanBeMoved = true;
    }
}





