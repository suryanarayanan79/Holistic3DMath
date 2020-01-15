using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateE : MonoBehaviour
{
 
public Vector3 eulerAngles;
Matrix rotaionMatrix;
float angle;
Coords axis;

void Start(){
    rotaionMatrix = HolisticMath.GetRotaionMatrix(eulerAngles.x * Mathf.Deg2Rad,false,
                                                    eulerAngles.y * Mathf.Deg2Rad,false,
                                                    eulerAngles.z * Mathf.Deg2Rad,false);
    angle = HolisticMath.GetRotaionAxisAngle(rotaionMatrix);
    axis = HolisticMath.GetRotationAxis(rotaionMatrix,angle);
}
    // Update is called once per frame
    void Update()
    {
        Coords quaternion = HolisticMath.Quaternion(axis,angle);
        transform.rotation *= new Quaternion(quaternion.x,quaternion.y,quaternion.z,quaternion.w);
        // transform.forward = HolisticMath.Rotate(new Coords(this.transform.forward,0),
        //                                         1 * Mathf.Deg2Rad,false,
        //                                         1 * Mathf.Deg2Rad,false,
        //                                         1 * Mathf.Deg2Rad,false).ToVector();
    }
}
