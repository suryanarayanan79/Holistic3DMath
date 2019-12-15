using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane 
{
    Coords pointA;
    Coords pointB;

    Coords pointC;
    Coords vectorV;
    Coords vectorU;

    public Plane(Coords a,Coords b,Coords c){
        pointA = a;
        vectorV = b - a;
        vectorU = c - a;
    }

    public Plane(Coords A,Vector3 v, Vector3 u){
        pointA = A;
        vectorU = new Coords(u.x,u.y,u.z);
        vectorV = new Coords(v.x,v.y,v.z);
    }

    public Coords Lerp(float s , float t){
        float xst = pointA.x + vectorU.x * s + vectorV.x * t;
        float yst = pointA.y + vectorU.y * s + vectorV.y * t;
        float zst = pointA.z + vectorU.z * s + vectorV.z * t;
        return new Coords(xst,yst,zst);
    }
}
