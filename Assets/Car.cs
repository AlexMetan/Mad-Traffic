
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Transform [] rims;
    [SerializeField] Transform [] wheels;
    Transform thisTransform;
    [SerializeField] int buttonStat;
    [SerializeField] Transform carTransform;
    void Start()
    {
        thisTransform=transform;
    }
    void Update()
    {
        RotateWheel();
        if(buttonStat!=0)
            Move(buttonStat);
        RotateCar(buttonStat);
        WheelRotation(-25);
        
    }
    void RotateWheel()
    {
        foreach (Transform item in rims)
        {
            item.Rotate(0,0,-10);
        }
    }
    void Move(float pos)
    {
        Vector3 newPos= new Vector3(thisTransform.position.x, thisTransform.position.y,thisTransform.position.z+pos);
        thisTransform.position=Vector3.MoveTowards(thisTransform.position,newPos,2f*Time.deltaTime);
    }
    public void SetStatement(int value)
    {
        buttonStat=value;
    }
    void RotateCar(float angle)
    {
        carTransform.localRotation=Quaternion.RotateTowards(carTransform.localRotation,Quaternion.AngleAxis(angle,Vector3.right),2*Time.deltaTime);
    }
    void WheelRotation(float angle)
    {       
        angle*=buttonStat;     
        foreach (Transform item in wheels)
        {
            item.localRotation=Quaternion.RotateTowards(item.localRotation,Quaternion.AngleAxis(angle,Vector3.up),5);   
        }   
            
    }
}
