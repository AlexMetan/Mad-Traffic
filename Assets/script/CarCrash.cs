using UnityEngine;

public class CarCrash : MonoBehaviour
{
    [SerializeField] StartGame startGame;
    [SerializeField] GameObject spawn;
    [SerializeField] MainUi mainUi;
    
    void OnTriggerEnter(Collider col) 
    {
        if(col.transform.gameObject.tag=="Traffic Car")
        {
            SaveBestDistance();
            startGame.CanvasObjectsSetActive(false,false,true);
            Params.CarCrashed=true;
            mainUi.SetTextLose();
        }
    }
    void SaveBestDistance()
    {
        float bestScore=PlayerPrefs.GetFloat("distance");
        float newScore=mainUi.GetDistanceToKMh(Params.DistanceKm);
        if(bestScore<newScore)
        {
            PlayerPrefs.SetFloat("distance",newScore);
        }
    }
}
