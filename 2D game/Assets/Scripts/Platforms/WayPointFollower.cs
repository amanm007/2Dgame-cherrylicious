using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //GameObject cuz our ways points are Empty Game Objects
    // we create an array cuz we could have many gameobjects
    //we set the waypoints in the editor;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;




    
    void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position)<.1f) //if the distance between current waypoint and our Moving PLatform(transform.position)
            //is less than 0 or a small value(will be less buggy)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex>=waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);
        //makes the platform move towards the current waypoint with a speed*Time.deltaTime
        //deltaTime is important as its under update
        //Time.deltaTime is pretty much value of Frames Per Seconds



        
    }
}
