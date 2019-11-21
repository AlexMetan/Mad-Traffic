using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] GameObject mainMenu;
    [SerializeField] ShopCars[] shopCars;
    public void GoToShop(bool value)
    {
        shop.SetActive(value);
        mainMenu.SetActive(!value);
    }
    public void BuyCar(int id)
    {
        int money=PlayerPrefs.GetInt("score");
        if(money>=Params.CarPrice[id])
        {
            money-=Params.CarPrice[id];
             
            string carId="carShop"+id;
            PlayerPrefs.SetInt(carId,1);
            shopCars[id].CarInGarage();
            shopCars[id].CarLock();
            
            Debug.Log(PlayerPrefs.GetInt(carId));
        }
    }
}
