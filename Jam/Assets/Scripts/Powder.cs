using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powder : MonoBehaviour
{
    [SerializeField] Tile tile;
    [SerializeField] GridManager gridManager;
    public GameObject PowderControllerTransformChangeTo;
    private Rigidbody2D rb;
    public bool powderObjectIsPickedUp = false;
    Controller controller;

    private void OnMouseDown()
    {
        Debug.Log("Working!");

        if (gridManager.powderObjectIsPickedUp == false)
        {
            gridManager.powderObjectIsPickedUp = true;
            gridManager.ClickedPowderObject = gameObject;
            controller.objectIsPickedUp = false;
            //objectIsPutDown = false;

        }
    }
    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<Controller>();

        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        gridManager.powderObjectIsPickedUp = false;

    }
   /* public void changePositionToSelectedTile()
    {
        gameObject.transform.position = PowderControllerTransformChangeTo.transform.position;
        gridManager.PowderControllerTransformChangeTo = null;
        gridManager.powderObjectIsPickedUp = false;
    }*/
}
