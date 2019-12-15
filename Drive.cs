using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // transform.Translate(0, translation, 0);
        //move towards world up.
        //need to convert to local space.
        Vector3 direction = new Vector3(0,translation,0);
        Vector3 facingDirection = transform.up;
        // what is the move direction of the tank
        Vector3 currentPos = transform.position;
        transform.position = HolisticMath.Translate(new Coords(0,translation,0),
        new Coords(currentPos.x,currentPos.y,currentPos.z),
        new Coords(facingDirection.x,facingDirection.y,facingDirection.z)).ToVector();
        // transform.Rotate(0, 0, -rotation);
        Vector3 temp = transform.up;
        float angleInRadians = rotation * Mathf.Deg2Rad;
        transform.up = HolisticMath.Rotate(new Coords(temp.x,temp.y,temp.z),angleInRadians,true).ToVector();
    }
}
