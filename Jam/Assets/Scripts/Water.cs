using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Controller")
        {
            Debug.Log("You Lost !!!");
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Powder")
        {
            Destroy(other.gameObject);
        }
        

    }
}
