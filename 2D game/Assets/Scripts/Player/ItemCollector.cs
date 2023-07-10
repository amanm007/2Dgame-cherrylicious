using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int cherryCount=0;
    [SerializeField] private Text cherriesText; //referencing our Text GameObject 
    [SerializeField] private AudioSource collect;




    private void OnTriggerEnter2D(Collider2D collision) //to mave Ontriggger collision for collectable items
        //only used when we have checked onTrigger on Box Collider2D, if you havent used OnTrigger, thhen used OnCollisionEnter 
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            collect.Play();
            Destroy(collision.gameObject);//if collided then delete the collsion object
            cherryCount++;
            cherriesText.text="Cherries: "+ cherryCount; //Text part our TextGameObJECT , set it to cherries + our cherrycount


            

        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
