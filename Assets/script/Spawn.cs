using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] float [] trafficPositionsZ;
    [SerializeField] GameObject [] trafficPrefab;
    List <Transform> trafficList;
    float time;

    void Start()
    {
        trafficList = new List<Transform>();
    }
    void Update()
    {
        CheckTrafficPosition();
        TimeToSpawn();
    }
    void SpawnTraffic()
    {
        int randPos = Random.Range(0,trafficPositionsZ.Length);
        int randPrefab = Random.Range(0,trafficPrefab.Length);
        Vector3 trafficStartPosition = new Vector3(100,0,trafficPositionsZ[randPos]);
        GameObject carTraffic=Instantiate(trafficPrefab[randPrefab],trafficStartPosition,Quaternion.identity);
    }
    void CheckTrafficPosition()
    {
        for(byte i = 0;i<trafficList.Count;i++)
        {
            if(trafficList[i].transform.position.x<=-5)
            {
                Destroy(trafficList[i]);
                trafficList.RemoveAt(i);
            }
        }
    }
    void TimeToSpawn()
    {
        time+=Time.deltaTime;
        if(time>=.5f)
        {
            SpawnTraffic();
            time=0;
        }
    }
}
