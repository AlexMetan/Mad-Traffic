using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    Transform thisTransform;
    [SerializeField] Vector3 startPosition;
    [SerializeField] Vector3 endPosition;
    [SerializeField] Transform [] roads;
    [SerializeField] float roadSpeed;
    
    void Start()
    {
        thisTransform=transform;        
    }
    void FixedUpdate()
    {
        MoveRoad();
    }
    void MoveRoad()
    {
      foreach (Transform item in roads)
      {
          if(item.position==endPosition)
          {
            item.position=startPosition;
          }
          else 
          item.position=Vector3.MoveTowards(item.position,endPosition,roadSpeed);
      }
    }
}
