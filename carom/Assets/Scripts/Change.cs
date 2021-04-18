using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject strike;
    [SerializeField] GameObject puck;
    public void Striker()
    {
      puck.SetActive(false);
      strike.SetActive(true);

    }
    public void Pucks()
    {
      strike.SetActive(false);
      puck.SetActive(true);
    }
}
