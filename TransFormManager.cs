using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransFormManager : MonoBehaviour
{

    public  GameObject point;
    public float angle;
    public Vector3 translation;
    // Start is called before the first frame update
    void Start()
    {
        Coords pos = new Coords(point.transform.position,1);
        Vector3 temp = HolisticMath.Translate(pos,
        new Coords(new Vector3(translation.x,translation.y,translation.z),0)).ToVector();
        point.transform.position = temp;
    }
}
