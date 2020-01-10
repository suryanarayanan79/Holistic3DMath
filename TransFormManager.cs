using UnityEngine;

public class TransFormManager : MonoBehaviour
{

    public  GameObject[] points;
    public float angle;
    public Vector3 translation;
    public Vector3 scale;
    public GameObject center;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 c = new Vector3(center.transform.position.x,center.transform.position.y,center.transform.position.z);

        foreach (GameObject point in points){
            Coords pos = new Coords(point.transform.position,1);
            pos = HolisticMath.Translate(pos,new Coords(new Vector3(-c.x,-c.y,-c.z),0));
            // point.transform.position = HolisticMath.Translate(pos,
            // new Coords(new Vector3(translation.x,translation.y,translation.z),0)).ToVector();
            pos = HolisticMath.ScaleTransForm(pos,scale.x,scale.y,scale.z);
            point.transform.position = HolisticMath.Translate(pos,
            new Coords(new Vector3(c.x,c.y,c.z),0)).ToVector();
        }
    }
}
