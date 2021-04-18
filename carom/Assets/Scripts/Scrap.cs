using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject plane;
    [SerializeField] Slider slider;
    int i = 2;
    public void Change(string s){
      plane.SetActive(true);
      while(i<=100){
        slider.value = i;
       i+=2;
     }

    SceneManager.LoadScene(s);
  }

}
