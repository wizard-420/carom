using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider){
      string check = PlayerPrefs.GetString("turn");
      if(collider.CompareTag("coins") )//|| collider.gameObject.tag == "striker"){
      {
        if(check == "player1"){
          PlayerPrefs.SetString("turn","lockplayer1");
        }
        if(PlayerPrefs.GetString("queen") == "hitbyblack"){
          PlayerPrefs.SetString("queen","");
          GameManager.Instance.CoinCollected(collider.gameObject);
        }
        else{
          GameManager.Instance.CoinCollected(collider.gameObject);
        }
        }

      if(collider.CompareTag("white") ){
        if(check == "player2"){
          PlayerPrefs.SetString("turn","lockplayer2");
        }
        if(PlayerPrefs.GetString("queen") == "hitbywhite"){
          PlayerPrefs.SetString("queen","");
          GameManager.Instance.WhiteCoinCollected(collider.gameObject);
        }
        else{
          GameManager.Instance.WhiteCoinCollected(collider.gameObject);
        }


        }
       if(collider.CompareTag("striker")){
         if(check == "player1" || check == "lockplayer1"){
          // print("fine for black");
           if(PlayerPrefs.GetString("queen") == "hitbyblack"){
             PlayerPrefs.SetString("queen","");
             GameManager.Instance.Fine("blackqueen");
           }
           else{
             GameManager.Instance.Fine("black");
           }

         }
         if(check == "player2" || check == "lockplayer2"){
           // print("fine for white");
            if(PlayerPrefs.GetString("queen") == "hitbywhite"){
              PlayerPrefs.SetString("queen","");
              GameManager.Instance.Fine("whitequeen");
            }
            else{
              GameManager.Instance.Fine("white");
            }

         }

         collider.GetComponent<Striker>().Reset();
         //collider.transform.position = new Vector3(0.1021953f,-0.54f,-0.1114116f);

          }
          if(collider.CompareTag("queen")){
            if(check == "player1" || check == "lockplayer1"){
                PlayerPrefs.SetString("turn","lockplayer1");
                PlayerPrefs.SetString("queen","hitbyblack");
                GameManager.Instance.CoinCollected(collider.gameObject);
            }
            if(check == "player2" || check == "lockplayer2"){
            PlayerPrefs.SetString("turn","lockplayer2");
            PlayerPrefs.SetString("queen","hitbywhite");
            GameManager.Instance.WhiteCoinCollected(collider.gameObject);
            }

         }
    }
}
