using UnityEngine;

public class CarCrash : MonoBehaviour
{
    [SerializeField] StartGame startGame;
    [SerializeField] MainUi mainUi;
    [SerializeField] Car car;
    void Start()
    {
        car=FindObjectOfType<Car>().GetComponent<Car>();
        startGame=FindObjectOfType<StartGame>().GetComponent<StartGame>();
        mainUi=FindObjectOfType<MainUi>().GetComponent<MainUi>();
    }
    
    void OnTriggerEnter(Collider col) 
    {
        if(col.transform.gameObject.tag=="Traffic Car")
        {
            car.ResetBTNState();
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
