using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] float [] trafficPositionsZ;
    [SerializeField] GameObject [] trafficPrefab;
    List <GameObject> trafficList;
    Transform thisTransorm;
    float time;

    void Start()
    {
        trafficList = new List<GameObject>();
        thisTransorm=GetComponent<Transform>();
    }
    void Update()
    {
        if(!Params.GamePaused)
        {
            CheckTrafficPosition();
            TimeToSpawn();
        }
    }
    void SpawnTraffic()
    {
        int randPos = Random.Range(0,trafficPositionsZ.Length);
        int randPrefab = Random.Range(0,trafficPrefab.Length);
        Vector3 trafficStartPosition = new Vector3(200,0,trafficPositionsZ[randPos]);
        GameObject carTraffic=Instantiate(trafficPrefab[randPrefab],trafficStartPosition,Quaternion.identity,thisTransorm);
        trafficList.Add(carTraffic);
    }
    void CheckTrafficPosition()
    {
        for(byte i = 0;i<trafficList.Count;i++)
        {
            if(trafficList[i].transform.position.x<=-15||trafficList[i].transform.position.x<=-120)
            {
                Destroy(trafficList[i]);
                trafficList.RemoveAt(i);
            }
        }
    }
    void TimeToSpawn()
    {
        time+=Time.deltaTime;
        if(time>=1.2f)
        {
            SpawnTraffic();
            time=0;
        }
    }
    public void DeleteTraffic()
    {
       foreach(Transform child in thisTransorm)
       {
           trafficList.Clear();
           Destroy(child.gameObject);
       }
    }
}
