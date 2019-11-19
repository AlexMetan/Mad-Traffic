using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] GameObject mainMenu;

    public void GoToShop(bool value)
    {
        shop.SetActive(value);
        mainMenu.SetActive(!value);
    }
}
