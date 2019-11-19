using System.Collections;
using UnityEngine;

public class Road : MonoBehaviour
{
  Transform thisTransform;
  Rigidbody rb;
  [SerializeField] float startPosX;
  [SerializeField] float endPosX;
  [SerializeField] float roadlength;
  [SerializeField] Transform road;
  Vector3 newV;
  void Start()
  {
    thisTransform=transform;       
    rb=GetComponent<Rigidbody>(); 
    newV= new Vector3(endPosX,0,0);
    StartCoroutine(Move());
  }
  void Reposition()
  {
      thisTransform.position=new Vector3(road.position.x+roadlength,0,0);    
      StartCoroutine(Move());
  }  
  IEnumerator Move()
  {
    while(thisTransform.position.x!=endPosX)
    {
      if(!Params.GamePaused)
      {
        thisTransform.position= Vector3.MoveTowards(thisTransform.position,newV,Params.CarSpeed);
        yield return null;
        if(thisTransform.position.x==endPosX)
        {
          Reposition();
          
          yield break;
        }
      }
      else  yield return null;
    }
    
  }
}
