using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rotator : MonoBehaviour
{
    private bool isFliping = false;
    private int count = 0;
    public void FlipPlayer()
    {
        isFliping = true;
    }


    private void Update()
    {
        if (isFliping)
        {
            transform.eulerAngles += new Vector3(0, 0, 0.5f);
            Debug.Log(transform.eulerAngles.z);
            if(count == 0)
            {
                if (Mathf.Clamp(transform.eulerAngles.z, 0, 180) >= 180) 
                {
                    isFliping = false;
                    count = 1;
                }
            }
            else if (count == 1)
            {
                if(transform.eulerAngles.z <= 0 )
                {
                    isFliping = false;
                    count = 0;
                }
            }
            
        }
    }

}
