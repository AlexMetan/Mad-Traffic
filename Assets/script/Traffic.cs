using UnityEngine;

public class Traffic : MonoBehaviour
{
    Transform thisTransform;
    Vector3 newPosition;
    bool forwardDirection;
    float speed;
    float currentSpeed;
    bool carFromTheFront;
    bool carCrash;
    void Start()
    {
        thisTransform=transform;
        newPosition=new Vector3(-20,thisTransform.position.y,thisTransform.position.z);
        CheckDirection();
    }
    void Update()
    {
        if(!Params.GamePaused)
        {
            TrafficMove();
            CheckCarState();
        }
    }
    void TrafficMove()
    {
        thisTransform.position = Vector3.MoveTowards(thisTransform.position,newPosition,Params.CarSpeed*currentSpeed);
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
                forwardDirection=true;
            break;
        }
        RandomSpeed();
    }
    void RotateCar()
    {
        thisTransform.rotation = Quaternion.AngleAxis(180,Vector3.up);        
    }
    void RandomSpeed()
    {
        if(forwardDirection)
            speed=Random.Range(.01f,.5f);
        else 
            speed=Random.Range(1.2f,3);
        currentSpeed=speed;
    }
    void OnTriggerEnter(Collider col) 
    {
        if(col.gameObject.tag=="Traffic Car")
            carFromTheFront=true;
    }
    void OnTriggerExit(Collider col) 
    {
        if(col.gameObject.tag=="Traffic Car")
            carFromTheFront=false;
    }
    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag=="MainCar"||col.gameObject.tag=="Traffic Car")
            carCrash=true;
    }
    void CheckCarState()
    {
        if(!carCrash)
        {
            if(carFromTheFront)
                currentSpeed=.5f;
            else
                currentSpeed=speed;
        }
        else
            currentSpeed=Params.CarSpeed;        
    }   
}
