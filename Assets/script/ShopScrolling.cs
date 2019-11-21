using UnityEngine;

public class ShopScrolling : MonoBehaviour
{
    [SerializeField] GameObject[] shopCars;
    int currentCar=0;
    void Start()
    {
        DeactivatedAllCars();
        EnableCar();
    }
    public void NextCar()
    {
        if(currentCar<shopCars.Length-1)
            currentCar++;
        else 
            currentCar=0;
        DeactivatedAllCars();
        EnableCar();
    }
    public void PreviousCar()
    {
        if(currentCar>0)
            currentCar--;
        else 
            currentCar=shopCars.Length-1;
        DeactivatedAllCars();
        EnableCar();
    }    
    void EnableCar()
    {
        shopCars[currentCar].SetActive(true);
    }
    void DeactivatedAllCars()
    {
        foreach(GameObject obj in shopCars)
        {
            obj.SetActive(false);
        }
    }
}
