using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    // Update is called once per frame
    [SerializeField] private float speed = 2f; //2 full rotations of image per frame
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); //rotating along z axis;
        
    }
}
