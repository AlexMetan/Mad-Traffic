using UnityEngine;

public class Traffic : MonoBehaviour
{
    Transform thisTransform;
    Vector3 newPosition;

    void Start()
    {
        thisTransform=transform;
        newPosition=new Vector3(-100,thisTransform.position.y,thisTransform.position.z);
        CheckDirection();
    }
    void Update()
    {
        TrafficMove();
    }
    void TrafficMove()
    {
        thisTransform.position = Vector3.MoveTowards(thisTransform.position,newPosition,Params.CarSpeed*1.4f);
    }
    void CheckDirection()
    {
        switch(thisTransform.position.z)
        {
            case 9.3f:
                RotateCar();
            break;
            case 13.9f:
                RotateCar();
            break;
            default:
            break;
        }
    }
    void RotateCar()
    {
        thisTransform.rotation = Quaternion.AngleAxis(180,Vector3.up);
    }
}
