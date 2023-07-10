using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Player")//if our platform collides with the player
        {
            collision.gameObject.transform.SetParent(transform);//now this set the player as a child of the moving platform and inhibit transform values

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            ////if our platform exites its collision with the player
            /////break the io=nheritance
            //this way  if you set the layer for moving platform to ground and you jump on it 
            // then you would have to move the player so that it doesnt fall on the traps
            //damnn

            //ALSO COULD USE OnTriggerEnter but for that you d have to set another box collider and make it small 
            //then check the OnTrigger Box

        }
    }
}

