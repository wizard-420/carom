using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    Vector3 _initial;
    private Vector2 distance;
    
    private void Awake(){
      _initial = transform.position;

    }
    private void OnMouseDown(){
      GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnMouseUp(){
      GetComponent<SpriteRenderer>().color = Color.white;
      distance = _initial - transform.position;
      GetComponent<Rigidbody2D>().AddForce(distance * 250);
    }
    private void OnMouseDrag(){
     Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     transform.position = new Vector3(newPosition.x, newPosition.y);
  //   hold = newPosition.x;
   //Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   //transform.position = new Vector3(hold,newPosition.y);
 }
   }
