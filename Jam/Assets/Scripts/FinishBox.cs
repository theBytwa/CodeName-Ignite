using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishBox : MonoBehaviour
{
    public int collectedPowderCount;
    //public int controllerCanBePlaced;
    private void Start()
    {
        collectedPowderCount = 0;
    }




    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Powder")
        {
            collectedPowderCount = collectedPowderCount + 1;




            if (SceneManager.GetActiveScene().name == "SampleScene")
            {
                if (other.gameObject.tag == "Powder")
                {
                    Destroy(other.gameObject);

                }
            }
            if (SceneManager.GetActiveScene().name == "Level2")
            {
                if (other.gameObject.tag == "Powder" && collectedPowderCount == 2)
                {
                    Destroy(other.gameObject);

                }
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                if (other.gameObject.tag == "Powder" && collectedPowderCount == 3)
                {
                    Destroy(other.gameObject);

                }
            }

        }

      

    }
}
