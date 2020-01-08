using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    Matrix mm;
    // Start is called before the first frame update
    void Start()
    {
        float[] toMatrix = {1,2,3,4,5,6,7,8};
        mm = new Matrix(4,2,toMatrix);
       Debug.Log( mm.ToString());
    }

}
