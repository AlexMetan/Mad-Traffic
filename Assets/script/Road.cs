using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
  Transform thisTransform;
  Rigidbody rb;
  [SerializeField] float roadSpeed;
  [SerializeField] float startPosX;
  [SerializeField] float endPosX;
  [SerializeField] Transform road;
  Vector3 newV;
  void Start()
  {
    thisTransform=transform;       
    rb=GetComponent<Rigidbody>(); 
    newV= new Vector3(endPosX,0,0);
    StartCoroutine(Move());
  }
  void Update()
  {
    
  }
  
  void Reposition()
  {
      thisTransform.position=new Vector3(road.position.x+100,0,0);    
      StartCoroutine(Move());
  }  
  IEnumerator Move()
  {
    while(thisTransform.position.x!=endPosX)
    {
      thisTransform.position= Vector3.MoveTowards(thisTransform.position,newV,roadSpeed);
      yield return null;
      if(thisTransform.position.x==endPosX)
      {
        Reposition();
        
        yield break;
      }
    }
    
  }
}
