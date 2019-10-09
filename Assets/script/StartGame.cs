using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] Transform mainCamera;
    [SerializeField] Vector3 cameraStartPosition;
    [SerializeField] Vector3 cameraDefPosition;
    [SerializeField] GameObject trafficSpawner;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject menuUI;
    void Start()
    {
        CameraPositionOnStart();
        TrafficSpawnerSetActive(false);
        MainUISetActive(false);
        TrafficSpawnerSetActive(false);
    }
    void MainUISetActive(bool value)
    {
        mainUI.SetActive(value);
        menuUI.SetActive(!value);

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
        StartCoroutine(MoveCameraToDef());
        
    }
    IEnumerator MoveCameraToDef()
    {
        while (mainCamera.position!=cameraDefPosition)
        {
            mainCamera.position=Vector3.MoveTowards(mainCamera.position,cameraDefPosition,1);
            yield return null;
        }
        TrafficSpawnerSetActive(true);
        MainUISetActive(true);
        yield break;
    }
}
