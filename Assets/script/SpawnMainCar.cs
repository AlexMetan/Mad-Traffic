using UnityEngine;

public class SpawnMainCar : MonoBehaviour
{
    [SerializeField] GameObject[] currentCar;
    int currentCarId;
    [SerializeField]Vector3 carSpawnPos;

    void Start()
    {
        SpawnCar();
    }
    public void SpawnCar()
    {
        GetCurrentCarId();
        Instantiate(currentCar[currentCarId],carSpawnPos,Quaternion.identity,transform);
    }
    void GetCurrentCarId()
    {
        currentCarId=PlayerPrefs.GetInt("currentCar");
    }
    public void DeleteOldCar()
    {
        foreach (Transform child in transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
