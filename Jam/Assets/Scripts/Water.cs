using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (other.gameObject.name == "Controller"|| other.gameObject.tag == "Powder")
        {
            Debug.Log("You Lost !!!");
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }       
    }
}
