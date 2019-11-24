using UnityEngine;

public class CarStatement : MonoBehaviour
{
    [SerializeField] Car car;
    void Start()
    {
        car = FindObjectOfType<Car>();
    }
    public void SetStatement(int value)
    {
        if(!Params.BlockMovement)
            car.ButtonState=value;
        else 
            car.ButtonState=0;
    }
    public void SetStatementTorque(int value)
    {
        car.TorqueState=value;
    }
    void Update() 
    {
        if(car==null)
            car = FindObjectOfType<Car>();    
    }
}
