using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScrolling : MonoBehaviour
{
    [SerializeField] GameObject[] shopCars;
    int currentCar=0;
    GameObject [] carItems;
    void Start()
    {
        carItems=new GameObject[shopCars.Length];
        ShowCars();
        DeactivatedAllCars();
        EnableCar();
    }

    // Update is called once per frame
   
    void ShowCars()
    {
        for(byte i=0;i<shopCars.Length;i++)
        {
            GameObject newBox=Instantiate(shopCars[i],transform.position,Quaternion.identity,transform);
            carItems[i]=newBox;
        }
    }
    public void NextCar()
    {
        if(currentCar<shopCars.Length-1)
        {
            currentCar++;
        }
        DeactivatedAllCars();
        EnableCar();
    }
    public void PreviousCar()
    {
        if(currentCar>0)
        {
            currentCar--;
            DeactivatedAllCars();
            EnableCar();
        }
    }    
    void EnableCar()
    {
        carItems[currentCar].SetActive(true);
    }
    void DeactivatedAllCars()
    {
        foreach(GameObject obj in carItems)
        {
            obj.SetActive(false);
        }
    }
}
