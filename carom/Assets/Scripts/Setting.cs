using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] GameObject setting;
    [SerializeField] GameObject pro;
    public void Activate(){
      setting.SetActive(true);
    }
    public void Activatepro(){
      pro.SetActive(true);
    }
    public void Deactivatepro(){
      pro.SetActive(false);
    }
    public void Deactivate(){
      setting.SetActive(false);
    }

}
