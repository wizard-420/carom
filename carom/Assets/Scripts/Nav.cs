using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nav : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    public void Navigation(GameObject active){
      for(int i=0 ; i < panels.Length; i++){
        panels[i].SetActive(false);
      }
      active.SetActive(true);
    }
}
