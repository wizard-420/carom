using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] GameObject panel;
   [SerializeField] private GameObject panel1;

    public GameObject Panel1 { get => panel1; set => panel1 = value; }


    public void Back(){
     panel.SetActive(false);
   }
   public void Back1(){
     Panel1.SetActive(false);
   }
    public void Initiate()
    {
     panel.SetActive(true);

   }
   public void City(){
     Panel1.SetActive(true);
   }

   }
