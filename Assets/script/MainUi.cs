using UnityEngine.UI;
using UnityEngine;

public class MainUi : MonoBehaviour
{
    [SerializeField] Text textDistance;
    [SerializeField] Text textSpeed;
   
    void Update()
    {
        SetText();
    }
    void SetText()
    {
        textDistance.text="Distance:  "+Mathf.Floor(Params.DistanceKm*100)/100+" km";
        textSpeed.text="Speed:  "+Params.GetSpeed()+" km/h";
    }
}
