using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*if (other.gameObject.name == "Controller")
        {
            Debug.Log("You Won <3");
        }*/
        if (other.gameObject.tag == "Powder")
        {
            Destroy(other.gameObject);
        }

    }
}
