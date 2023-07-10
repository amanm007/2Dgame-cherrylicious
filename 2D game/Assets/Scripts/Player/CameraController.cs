using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;// cuz we need player transform values
    //serilize cuz then we can drag and rop our player object

    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); //transofrm is cameras tranform variable

    }
}
