using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Transform [] rims;
    [SerializeField] Transform [] frontWheels;
    Transform thisTransform;
    [SerializeField] int buttonState;
    [SerializeField] int torqueState;
    [SerializeField] Transform carTransform;    
    [SerializeField] float maxSpeed;
    [SerializeField] float minZ,maxZ;
    [SerializeField] float currentZ;
    float minSpeed;
    float currentSpeed;

    public int ButtonState { get => buttonState; set => buttonState = value; }
    public int TorqueState { get => torqueState; set => torqueState = value; }

    void Start()
    {
        thisTransform=transform;
        minSpeed=Params.CarSpeed;
        currentSpeed=Params.CarSpeed;
    }
    void Update()
    {
        if(!Params.GamePaused)
        {
            RotateWheel();
            if(buttonState!=0)
                Move();
            Torque();
            RotateCar(buttonState);
            WheelRotation(-15);
            SetMinMaxSpeed();
            if(!Params.CarCrashed&&!Params.InMenu)
                SetDistance();      
        }         
    }
    void RotateWheel()
    {
        foreach (Transform item in rims)
        {
            item.Rotate(0,0,-10);
        }
    }
    void Move()
    {
        currentZ=thisTransform.position.z+buttonState;
        SetMinMaxPositionZ();
        Vector3 newPos= new Vector3(thisTransform.position.x, thisTransform.position.y,currentZ);
        thisTransform.position=Vector3.MoveTowards(thisTransform.position,newPos,12f*Time.deltaTime);
    }
   
    void RotateCar(float angle)
    {
        carTransform.localRotation=Quaternion.RotateTowards(carTransform.localRotation,Quaternion.AngleAxis(angle*5,Vector3.right),20*Time.deltaTime);
    }
    void WheelRotation(float angle)
    {       
        angle*=buttonState;     
        foreach (Transform item in frontWheels)
        {
            item.localRotation=Quaternion.RotateTowards(item.localRotation,Quaternion.AngleAxis(angle,Vector3.up),8);   
        }               
    }
    void Torque()
    {
        if(!Params.InMenu&&!Params.CarCrashed)
        {
            if(torqueState!=0)
            {
                currentSpeed+=0.01f*torqueState;
                Params.CarSpeed=currentSpeed;
            }
            else 
            {
                currentSpeed-=0.00025f;
                Params.CarSpeed=currentSpeed;
            }
        }
        else 
        {
            Params.CarSpeed=Params.DefSpeed;
            currentSpeed=Params.DefSpeed;
        }
    }
    void SetMinMaxSpeed()
    {
        currentSpeed=Mathf.Clamp(currentSpeed,minSpeed,maxSpeed);
    }
    void SetMinMaxPositionZ()
    {
        currentZ=Mathf.Clamp(currentZ,minZ,maxZ);
    }
    void SetDistance()
    {
        Params.DistanceKm+=Params.GetSpeed()*0.00001f;
    }
}
