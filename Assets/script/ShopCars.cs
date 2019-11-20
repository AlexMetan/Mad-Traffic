using UnityEngine.UI;
using UnityEngine;

public class ShopCars : MonoBehaviour
{
    [Header("Car Config")]
    [SerializeField][Range(0,375)] int[] carConfig;
    [Header("Images")]
    [SerializeField] Image[] carConfigImage;
    [Header("GameObject")]
    [SerializeField] GameObject locked; 
    [SerializeField] GameObject btnBuy;
    [SerializeField] GameObject btnTake;
    [SerializeField] GameObject priceObj;
    [Header("Value")]
    [SerializeField] int priceValue;
    [SerializeField] int carId;

    [SerializeField] bool carPurchased;
    void Start()
    {
        SetConfig();
        if(carId!=0)
            carPurchased=CarInGarage();
        CarLock();
    }
    void SetConfig()
    {
        for(int i=0;i<carConfig.Length;i++)
        {
            carConfigImage[i].GetComponent<RectTransform>().sizeDelta=new Vector2(carConfig[i],20);
        }
    }
    void CarLock()
    {
        if(carPurchased)
        {
            BuyCarActive(false);
        }
    }
    void BuyCarActive(bool value)
    {
        priceObj.SetActive(value);
        btnBuy.SetActive(value);
        locked.SetActive(value);
        btnTake.SetActive(!value);
    }
    bool CarInGarage()
    {
        string carName="carShop"+carId;
        if(PlayerPrefs.GetInt("carName")==1)
        {
            return true;
        }
        else return false;
    }
}
