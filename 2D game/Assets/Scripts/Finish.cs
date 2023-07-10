using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;




    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();


        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player" && !levelCompleted)
        {
           
            finishSound.Play();
            levelCompleted = true; //this we sound doesnt get played multiple times 
            Invoke("CompleteLevel", 3f); //to delay the level change
            


        }
        
    }

    private void CompleteLevel()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
