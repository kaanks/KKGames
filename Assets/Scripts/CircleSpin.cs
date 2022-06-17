using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpin : MonoBehaviour
{
    public float speed;
    public int DirectionOfRotation;//only 1 or -1

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,DirectionOfRotation*speed*Time.deltaTime);
    }
}
