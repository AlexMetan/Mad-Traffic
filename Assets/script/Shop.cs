using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] GameObject mainMenu;
    [SerializeField] ShopCars[] shopCars;
    [SerializeField] MainUi mainUi;
    public void GoToShop(bool value)
    {
        mainUi.ReloadMenu();
        shop.SetActive(value);
        mainMenu.SetActive(!value);
    }
    public void BuyCar(int id)
    {
        int money=PlayerPrefs.GetInt("score");
        if(money>=Params.CarPrice[id])
        {
            money-=Params.CarPrice[id];
            PlayerPrefs.SetInt("score",money); 
            string carId="carShop"+id;
            PlayerPrefs.SetInt(carId,1);
            shopCars[id].CarInGarage();
            shopCars[id].CarLock();
        }
    }
    public void TakeCar(int id)
    {
        PlayerPrefs.SetInt("currentCar",id);
    }
}
