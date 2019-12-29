using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LINETYPE{
    LINE,
    SEGMENT,
    RAY
};
public class Line 
{
 Coords pointA;
 Coords pointB;
 Coords v;
 LINETYPE type;

 public Line(Coords a , Coords b,LINETYPE _type = LINETYPE.LINE){
     pointA = a;
     pointB = b;
     v = b - a;
     type = _type;
 }
// Get a ponint at time t. linear interpolation.
 public Coords Lerp(float t){
     //a = b+ v *t;
     if(type == LINETYPE.SEGMENT){
         t = Mathf.Clamp(t,0,1);
     }else if(type == LINETYPE.RAY && t < 0){
         t = 0;
     }
     float xt = pointA.x + v.x * t;
     float yt = pointA.y + v.y * t;
     float zt = pointA.z + v.z * t;
     return new Coords(xt,yt,zt);
 }
 
 public void DrawLine(float width, Color col){
    Coords.DrawLine(pointA,pointB,width,col);
 }

 public float IntersectAt(Line l){
     if(HolisticMath.Dot(Coords.Perp(l.v),this.v) == 0){
        // they are parallel vectors.
        return float.NaN;
     }
    Coords C = l.pointA - this.pointA;
    Coords prepU = Coords.Perp(l.v);
    float t1 = HolisticMath.Dot(prepU,C); 
    float t2 = HolisticMath.Dot(prepU ,this.v);
    return t1 / t2;
 }

}
