using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] Transform mainCamera;
    [SerializeField] Transform car;
    [Header("Vector3")]
    [SerializeField] Vector3 cameraStartPosition;
    [SerializeField] Vector3 cameraDefPosition;
    [SerializeField] Vector3 carRestartPos;
    [SerializeField] Vector3 defCarPosition;
    [Header("Objects")]
    [SerializeField] GameObject trafficSpawner;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject crashUI;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject pauseButton;
    [Header("Classes")]
    [SerializeField] Spawn spawn;
    [SerializeField] MainUi mainUi;
    [SerializeField] PauseAnimation pauseAnimation;
    void Start()
    {
        CameraPositionOnStart();
        TrafficSpawnerSetActive(false);
        CanvasObjectsSetActive(true,false,false);
        TrafficSpawnerSetActive(false);
        Params.CarCrashed=false;
        Pause(false);
        SetTimerActive(false);
        SetPauseButtonActive(true);
    }
    public void CanvasObjectsSetActive(bool menu,bool main,bool crashed)
    {
        menuUI.SetActive(menu);
        mainUI.SetActive(main);
        crashUI.SetActive(crashed);
    }
    void CameraPositionOnStart()
    {
        mainCamera.position=cameraStartPosition;
    }
    void TrafficSpawnerSetActive(bool value)
    {
        trafficSpawner.SetActive(value);
    }
    public void StartMainGame()
    {
        StopAllCoroutines();
        SetDefRotation();
        StartCoroutine(MoveCameraToDef(cameraDefPosition,true));
        StartCoroutine(ChangeCarPos());
    }
    public void GoToMenu()
    {
        car.transform.position=carRestartPos;
        Pause(false);
        StopAllCoroutines();
        StartCoroutine(ChangeCarPos());
        StartCoroutine(MoveCameraToDef(cameraStartPosition,false));
        spawn.DeleteTraffic();
        mainUi.ReloadMenu();
    }
    IEnumerator MoveCameraToDef(Vector3 newPosition,bool value)
    {
        while (mainCamera.position!=newPosition)
        {
            if(!Params.GamePaused)
            {
                mainCamera.position=Vector3.MoveTowards(mainCamera.position,newPosition,1);
                yield return null;
            }
            else yield return null;
        }
        TrafficSpawnerSetActive(value);
        CanvasObjectsSetActive(!value,value,false);
        Params.InMenu=!value;
        ResetDistance();
        yield break;
    }
    public IEnumerator ChangeCarPos()
    {
        Params.BlockMovement=true;
        while (car.position!=defCarPosition)
        {
            if(!Params.GamePaused)
            {
                car.position=Vector3.MoveTowards(car.position,defCarPosition,0.2f);
                yield return null;
            }
            else  yield return null;
        }
        Params.BlockMovement=false;
        yield break;
    }
    public void RestartGame()
    {
        Pause(false);
        spawn.DeleteTraffic();
        SetDefRotation();
        car.position=carRestartPos;
        StopAllCoroutines();
        StartCoroutine(ChangeCarPos());
        TrafficSpawnerSetActive(true);
        CanvasObjectsSetActive(false,true,false);
        ResetDistance();
        Params.CarCrashed=false;
    }
    void ResetDistance()
    {
        Params.DistanceKm=0;
    }
    void SetDefRotation()
    {
        car.transform.rotation=Quaternion.Euler(Vector3.zero);
    }
    public void Pause(bool value)
    {
        HidePausePanel(value);
        SetParamsPause(value);        
    }
    void HidePausePanel(bool value)
    {
        pausePanel.SetActive(value);
    }
    void SetParamsPause(bool value)
    {
        Params.GamePaused=value;
        SetPauseButtonActive(!value);
    }
    void SetTimerActive(bool value)
    {
        timerText.SetActive(value);
    }
    void SetPauseButtonActive(bool value)
    {
        pauseButton.SetActive(value);
    }
    IEnumerator TimerAfterPouse()
    {
        pauseAnimation.PlayAnimationOut();
        yield return new WaitForSeconds(.4f);
        SetTimerActive(true);
        HidePausePanel(false);
        float timer=3;
        while(timer>1)
        {
            timer-=Time.deltaTime;
            mainUi.SetTimerText(Mathf.RoundToInt(timer));
            yield return null;
        }
        SetParamsPause(false);
        SetTimerActive(false);
        
        SetPauseButtonActive(true);
        yield break;
    }
    public void Continue()
    {
        StartCoroutine(TimerAfterPouse());
    }
}
