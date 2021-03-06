﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{
    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquared = Square(point1.x - point2.x) + 
                            Square(point1.y - point2.y) + 
                            Square(point1.z - point2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public Coords Lerp(Coords A, Coords B, float t)
    {
        t = Mathf.Clamp(t, 0, 1);
        Coords v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
        float xt = A.x + v.x * t;
        float yt = A.y + v.y * t;
        float zt = A.z + v.z * t;

        return new Coords(xt, yt, zt);
    }

    static public Coords Translate(Coords position,Coords vector){
// return Coords = translation matrix * position 
    float[] translationValues =
                {
                    1,0,0,vector.x,
                    0,1,0,vector.y,
                    0,0,1,vector.z,
                    0,0,0,1   
                };
        Matrix translationMatrix = new Matrix(4,4,translationValues);
        Matrix pos = new Matrix(4,1,position.AsFloats());
        Matrix result = translationMatrix * pos;
        return result.AsCords();
    }

    static public Coords ScaleTransForm(Coords position,float scaleX,float ScaleY,float ScaleZ){
    float[] scaleValues =   {
        scaleX,0,0,0,
        0,ScaleY,0,0,
        0,0,ScaleZ,0,
        0,0,0,1
        };
        Matrix scaleMatrix = new Matrix(4,4,scaleValues);
        Matrix pos = new Matrix(4,1,position.AsFloats());
        Matrix result = scaleMatrix * pos;
        return result.AsCords();
    }

    static public float Square(float value)
    {
        return value * value;
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) /
                    (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); //radians.  For degrees * 180/Mathf.PI;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
        float angle = HolisticMath.Angle(forwardVector, direction);
        bool clockwise = false;
        if (HolisticMath.Cross(forwardVector, direction).z < 0)
            clockwise = true;

        Coords newDir = HolisticMath.Rotate(forwardVector, angle, clockwise);
        return newDir;
    }
    // Rotaion Matrix Construction using Quaternion.
static public Coords Quaternion(Coords axis,float angle /*in randians*/){
        Coords aNormal =  Coords.GetNormal(axis);
        float w = Mathf.Cos(angle  / 2.0f);
        float s = Mathf.Sin(angle  / 2.0f);
        //quaternion equation.
        Coords q = new Coords(aNormal.x * s ,aNormal.y * s , aNormal.z * s,w);
        return q;
    }
    static public Coords QRotate(Coords position, Coords axis,float angle /*degree*/){
        Coords aNormal =  Coords.GetNormal(axis);
        float w = Mathf.Cos(angle * Mathf.Deg2Rad / 2);
        float s = Mathf.Sin(angle * Mathf.Deg2Rad / 2);
        //quaternion equation.
        Coords q = new Coords(aNormal.x * s ,aNormal.y * s , aNormal.z * s,w);
        float[] quaternionValues = {
             1 - 2*q.y*q.y - 2*q.z*q.z, 2*q.x*q.y - 2*q.w*q.z,      2*q.x*q.z + 2*q.w*q.y,     0,
             2*q.x*q.y + 2*q.w*q.z,     1 - 2*q.x*q.x - 2*q.z*q.z,  2*q.y*q.z - 2*q.w*q.x,     0,
             2*q.x*q.z - 2*q.w*q.y,     2*q.y*q.z + 2*q.w*q.x,      1 - 2*q.x*q.x - 2*q.y*q.y, 0,
             0,                         0,                          0,                         1 };
        Matrix quaternionMatrix = new Matrix(4,4,quaternionValues);
        Matrix pos = new Matrix(4,1,position.AsFloats());
        Matrix result = quaternionMatrix * pos;
        return result.AsCords();
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) //in radians
    {
        if(clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }

        static public Coords Rotate(Coords point, float anglex, bool clockwisex,float angley,bool clockwisey,float anglez,bool clockwisez) //in radians
    {
        if(clockwisex)
        {
            anglex = 2 * Mathf.PI - anglex;
        }
        if(clockwisey){
            angley = 2* Mathf.PI - angley;
        }
        if(clockwisez){
            anglez = 2* Mathf.PI - anglez;
        }
        float [] roationValesX = {
            1,0,0,0,
            0,Mathf.Cos(anglex),-Mathf.Sin(anglex),0,
            0,Mathf.Sin(anglex),Mathf.Cos(anglex),0,
            0,0,0,1
        };

        Matrix XRoll = new Matrix(4,4,roationValesX);

        float [] roationValesY = {
            Mathf.Cos(angley),0,Mathf.Sin(angley),0,
            0,1,0,0,
            -Mathf.Sin(angley),0,Mathf.Cos(angley),0,
            0,0,0,1
        };

        Matrix YRoll = new Matrix(4,4,roationValesY);

        float [] roationValesZ = {
            Mathf.Cos(anglez),-Mathf.Sin(anglez),0,0,
            Mathf.Sin(anglez),Mathf.Cos(anglez),0,0,
            0,0,1,0,
            0,0,0,1
        };

        Matrix ZRoll = new Matrix(4,4,roationValesZ);

        Matrix pos = new Matrix(4,1,point.AsFloats());

        Matrix result = ZRoll * YRoll * XRoll * pos;
        return result.AsCords();
    }

    // Rotaion Matrix Construction using Euler Angles.
    static public Matrix GetRotaionMatrix( float anglex, bool clockwisex,float angley,bool clockwisey,float anglez,bool clockwisez) //in radians
    {
        if(clockwisex)
        {
            anglex = 2 * Mathf.PI - anglex;
        }
        if(clockwisey){
            angley = 2* Mathf.PI - angley;
        }
        if(clockwisez){
            anglez = 2* Mathf.PI - anglez;
        }
        float [] roationValesX = {
            1,0,0,0,
            0,Mathf.Cos(anglex),-Mathf.Sin(anglex),0,
            0,Mathf.Sin(anglex),Mathf.Cos(anglex),0,
            0,0,0,1
        };

        Matrix XRoll = new Matrix(4,4,roationValesX);

        float [] roationValesY = {
            Mathf.Cos(angley),0,Mathf.Sin(angley),0,
            0,1,0,0,
            -Mathf.Sin(angley),0,Mathf.Cos(angley),0,
            0,0,0,1
        };

        Matrix YRoll = new Matrix(4,4,roationValesY);

        float [] roationValesZ = {
            Mathf.Cos(anglez),-Mathf.Sin(anglez),0,0,
            Mathf.Sin(anglez),Mathf.Cos(anglez),0,0,
            0,0,1,0,
            0,0,0,1
        };

        Matrix ZRoll = new Matrix(4,4,roationValesZ);
        // the matrix multiplication is from right to left.
        Matrix result = ZRoll * YRoll * XRoll ;
        return result;
    }

    static public float GetRotaionAxisAngle(Matrix rotaion){
        float angle = 0;
        angle = Mathf.Acos((rotaion.GetValue(0,0) + rotaion.GetValue(1,1) + rotaion.GetValue(2,2) + rotaion.GetValue(3,3) - 2 ) * 0.5f);
        return angle;
    }

    // 
    static public Coords GetRotationAxis(Matrix rotation,float angle /*angle is in radians*/){
        float vx = (rotation.GetValue(2,1) - rotation.GetValue(1,2)) / 2 * Mathf.Sin(angle);
        float vy = (rotation.GetValue(2,0) - rotation.GetValue(0,2)) / 2 * Mathf.Sin(angle);
        float vz = (rotation.GetValue(1,0) - rotation.GetValue(0,1)) / 2 * Mathf.Sin(angle);
        return new Coords(vx,vy,vz,0);
    }
   
    static public Coords Translate(Coords position, Coords facing, Coords vector)
    {
        if (HolisticMath.Distance(new Coords(0, 0, 0), vector) <= 0) return position;
        float angle = HolisticMath.Angle(vector, facing);
        float worldAngle = HolisticMath.Angle(vector, new Coords(0, 1, 0));
        bool clockwise = false;
        if (HolisticMath.Cross(vector, facing).z < 0)
            clockwise = true;

        vector = HolisticMath.Rotate(vector, angle + worldAngle, clockwise);

        float xVal = position.x + vector.x;
        float yVal = position.y + vector.y;
        float zVal = position.z + vector.z;
        return new Coords(xVal, yVal, zVal);
    }

    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        float zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        Coords crossProd = new Coords(xMult, yMult, zMult);
        return crossProd;
    }
}
