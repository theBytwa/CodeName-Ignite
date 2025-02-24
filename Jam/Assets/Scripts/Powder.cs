using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Powder : MonoBehaviour
{
    [SerializeField] Tile tile;
    [SerializeField] GridManager gridManager;
    public GameObject PowderControllerTransformChangeTo;
    private Rigidbody2D rb;
    public bool powderObjectIsPickedUp = false;
    Controller controller;
    //public bool testBool = false;
    //public bool isClicked;

    private void OnMouseDown()
    {
        Debug.Log("Working!");

        if (gridManager.powderObjectIsPickedUp == false && controller.powderObjectCanComeNear)
        {
            controller.FindAllPowdersAndChangeTheBlocks();
            gridManager.powderObjectIsPickedUp = true;
            gridManager.ClickedPowderObject = gameObject;
            controller.objectIsPickedUp = false;
            //gridManager.test = true;
            //objectIsPutDown = false;
            gridManager.playIsClickedSwitchTimer();
            //ReachAllTheFingPrefabsAndTurnThemOn();
            powderObjectIsPickedUp = true;


        }
    }
    private void Start()
    {
        //isClicked = false;
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();

        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        gridManager.powderObjectIsPickedUp = false;
        powderObjectIsPickedUp = false;
    }

//<<<<<<< HEAD
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile" && other.gameObject.tag == "Controller")
        {

        }
    }
//=======
//>>>>>>> parent of 285af82 (safety push)
    void ReachAllTheFingPrefabsAndTurnThemOn()
    {
        
    }




}
