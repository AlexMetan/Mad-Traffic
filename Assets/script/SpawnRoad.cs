using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{
    [SerializeField] GameObject road;
    [SerializeField] List <GameObject> roadList;
    [SerializeField] Vector3 spawnPosition;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Spawn()
    {
        var roadL = Instantiate(road,spawnPosition,Quaternion.identity);
        roadList.Add(roadL);
    }
}
