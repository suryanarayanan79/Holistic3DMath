using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionManager : MonoBehaviour
{
    public GameObject[] points;
    public GameObject axisCenter;
    public Vector3 angle;
    public Vector3 rotaionAxis;
    // Start is called before the first frame update
    void Start()
    {
        angle = angle * Mathf.Deg2Rad;
        foreach(GameObject point in points){
            Coords position = new Coords(point.transform.position,1);
            Coords axis = new Coords(rotaionAxis,0);
            // rotaion is applied to the position.
            point.transform.position = HolisticMath.Rotate(position,angle.x,true,angle.y,true,angle.z,true).ToVector();
        }
        Matrix rot = HolisticMath.GetRotaionMatrix(angle.x,true,angle.y,true,angle.z,true);
        float angle2 = HolisticMath.GetRotaionAxisAngle(rot);
        Coords angleAxis  = HolisticMath.GetRotationAxis(rot,angle2);
        Coords.DrawLine(new Coords(Vector3.zero),(angleAxis)*3,0.1f,Color.yellow);
        Debug.Log("Axis" + angleAxis.ToString());
        Debug.Log("Angle" + angle2);
    }

}
