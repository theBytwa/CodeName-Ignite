using System.Collections;
using System.Collections.Generic;
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



    public bool objectIsPickedUp = false;
    //private bool objectIsPutDown = true;
    // Start is called before the first frame update
    void Start()
    {
        //rb = gameObject.AddComponent<Rigidbody2D>();
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();


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
            gridManager.ClickedPowderObject = null;
            
        }      
    }
    public void changePositionToSelectedTile()
    {
        gameObject.transform.position = ControllerTransformChangeTo.transform.position;
        ControllerTransformChangeTo = null;
        objectIsPickedUp = false;
    }
    
   

}





