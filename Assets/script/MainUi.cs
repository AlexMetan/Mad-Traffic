using UnityEngine.UI;
using UnityEngine;

public class MainUi : MonoBehaviour
{
    [SerializeField] Text textDistance;
    [SerializeField] Text textSpeed;
    [SerializeField] Text distanceFinal;
    [SerializeField] Text bestDistance;
    [SerializeField] Text score;
    [SerializeField] Text menuScore;
    [SerializeField] Text timerText;

    void Start()
    {
        ReloadMenu();
    }
    void Update()
    {
        SetText();
    }
    void SetText()
    {
        textDistance.text=GetDistanceToKMh(Params.DistanceKm)+" km";
        textSpeed.text=Params.GetSpeed()+" km/h";
    }
    public void SetTextLose()
    {
        distanceFinal.text="Distance:  "+GetDistanceToKMh(Params.DistanceKm)+" km";
        bestDistance.text="Best Distance:  "+PlayerPrefs.GetFloat("distance")+" km";
        score.text="Score:  "+GetNewScore();
        SaveScore();
    }
    public float GetDistanceToKMh(float distance)
    {
        return Mathf.Floor(distance*100)/100;
    }
    int GetNewScore()
    {
        return (int)(GetDistanceToKMh(Params.DistanceKm)*200);
    }
    void SaveScore()
    {
        int myScore=PlayerPrefs.GetInt("score");
        myScore+=GetNewScore();
        PlayerPrefs.SetInt("score",myScore);
        PlayerPrefs.Save();
    }
    public void ReloadMenu() 
    {
        menuScore.text=PlayerPrefs.GetInt("score").ToString();
    }
    public void SetTimerText(int value)
    {
        timerText.text=value.ToString();
    }
}
