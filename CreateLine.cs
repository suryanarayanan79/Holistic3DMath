﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    Line L1;
    Line L2;
    // Start is called before the first frame update
    void Start()
    {
        L1 = new Line(new Coords(-100,0,0),new Coords(200,150,0));
        L1.DrawLine(1,Color.red);
        L2 = new Line(new Coords(0,-100,0),new Coords(0,200,0));
        L2.DrawLine(1,Color.white);
        float timeOfIntersection = L1.IntersectAt(L2);
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = L1.Lerp(timeOfIntersection).ToVector();
    }

}
