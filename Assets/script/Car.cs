
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Transform [] rims;
    [SerializeField] Transform [] frontWheels;
    Transform thisTransform;
    [SerializeField] int buttonStat;
    [SerializeField] int torqueStat;
    [SerializeField] Transform carTransform;    
    [SerializeField] float maxSpeed;
    [SerializeField] float minZ,maxZ;
    [SerializeField] float currentZ;
    float minSpeed;
    float currentSpeed;
    void Start()
    {
        thisTransform=transform;
        minSpeed=Params.CarSpeed;
        currentSpeed=Params.CarSpeed;
    }
    void Update()
    {
        RotateWheel();
        if(buttonStat!=0)
            Move();
        Torque();
        RotateCar(buttonStat);
        WheelRotation(-15);
        SetMinMaxSpeed();
        SetDistance();       
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
        currentZ=thisTransform.position.z+buttonStat;
        SetMinMaxPositionZ();
        Vector3 newPos= new Vector3(thisTransform.position.x, thisTransform.position.y,currentZ);
        thisTransform.position=Vector3.MoveTowards(thisTransform.position,newPos,12f*Time.deltaTime);
    }
    public void SetStatement(int value)
    {
        buttonStat=value;
    }
    public void SetStatementTorque(int value)
    {
        torqueStat=value;
    }
    void RotateCar(float angle)
    {
        carTransform.localRotation=Quaternion.RotateTowards(carTransform.localRotation,Quaternion.AngleAxis(angle*5,Vector3.right),20*Time.deltaTime);
    }
    void WheelRotation(float angle)
    {       
        angle*=buttonStat;     
        foreach (Transform item in frontWheels)
        {
            item.localRotation=Quaternion.RotateTowards(item.localRotation,Quaternion.AngleAxis(angle,Vector3.up),8);   
        }               
    }
    void Torque()
    {
        if(torqueStat!=0)
        {
            currentSpeed+=0.01f*torqueStat;
            Params.CarSpeed=currentSpeed;
        }
        else 
        {
            currentSpeed-=0.00025f;
            Params.CarSpeed=currentSpeed;
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
