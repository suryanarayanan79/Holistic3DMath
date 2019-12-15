using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float translateY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float translateZ = Input.GetAxis("VerticalY")* speed * Time.deltaTime;
        transform.Translate(translateX,translateY,translateZ);
    }
}
