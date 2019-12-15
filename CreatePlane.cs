using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(new Coords(pointA.position),new Coords(pointB.position),new Coords(pointC.position));
        for(float s = 0 ; s <= 1.0f ; s += 0.1f){
            for(float t = 0 ; t <= 1.0f; t += 0.1f ){
                //create sphere and position it.
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s,t).ToVector();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
