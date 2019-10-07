using UnityEngine.UI;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    [SerializeField] Color normalColor;
    [SerializeField] Color pressedColor;
    Image thisImage;
    void Start()
    {
        thisImage=GetComponent<Image>();
    }
    public void ChangeColor(bool value)
    {
        if(value)
            thisImage.color=pressedColor;
        else 
            thisImage.color=normalColor;
    }

}
