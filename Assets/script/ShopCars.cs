using UnityEngine.UI;
using UnityEngine;

public class ShopCars : MonoBehaviour
{
    [Header("Car Config")]
    [SerializeField][Range(0,375)] int[] carConfig;
    [Header("UI")]
    [SerializeField] Image[] carConfigImage;
    [SerializeField] Button takeButton;
    [Header("GameObject")]
    [SerializeField] GameObject lockedObj; 
    [SerializeField] GameObject btnBuyObj;
    [SerializeField] GameObject btnTakeObj;
    [SerializeField] GameObject priceObj;
    [Header("Value")]
    [SerializeField] int priceValue;
    [SerializeField] int carId;
    int currentMoney;
    
    [SerializeField] bool carPurchased;
    void Start()
    {
        SetConfig();
        if(carId!=0)
            CarInGarage();
        CarLock();
    }
    void SetConfig()
    {
        for(int i=0;i<carConfig.Length;i++)
        {
            carConfigImage[i].GetComponent<RectTransform>().sizeDelta=new Vector2(carConfig[i],20);
        }
    }
    public void CarLock()
    {
        if(carPurchased)
        {
            BuyCarActive(false);
        }
    }
    void Update() {
        CheckButtonTake();
    }
    void BuyCarActive(bool value)
    {
        priceObj.SetActive(value);
        btnBuyObj.SetActive(value);
        lockedObj.SetActive(value);
        btnTakeObj.SetActive(!value);
    }
    public void CarInGarage()
    {
        string carName="carShop"+carId;
        if(PlayerPrefs.GetInt(carName)==1)
        {
            carPurchased=true;
        }
        else carPurchased=false;
    }    
    void CheckButtonTake()
    {
        if(PlayerPrefs.GetInt("currentCar")==carId)
            takeButton.interactable=false;
        else 
             takeButton.interactable=true;
    }
}
