using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
      get
      {
        if(_instance == null){
          _instance = GameObject.FindObjectOfType<GameManager>();
        }
        return _instance;
      }
    }
    public Transform collectpos;
    public Transform collectwhitepos;
    public Transform resetblack;
    public Transform resetwhite;
    public Transform resetqueen;
    public float offset = 0.3f;
    public float woffset = 0.3f;
    public int numberOfCoinsCollected;
    public Text white;
    public Text black;
    GameObject carrywhite;
    GameObject carryblack;
    public int numberOfwhiteCoinsCollected ;

    public enum GameState
    {
        carom,
        vs,
        point,
        pool,
        none
    }


    public GameState state;







    public void CoinCollected(GameObject collectedcoin){
        collectedcoin.SetActive(false);/*
        collectedcoin.GetComponent<CircleCollider2D>().isTrigger = true;
        collectedcoin.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        offset = 0.3f * numberOfCoinsCollected;
        collectedcoin.transform.position = new Vector2(collectpos.position.x - offset, collectpos.position.y);*/
        if(state == GameState.point)
        {
            numberOfCoinsCollected += 10;
        }
        else
        {
            numberOfCoinsCollected += 1;
        }
        carryblack = collectedcoin;
        black.text = numberOfCoinsCollected.ToString();
        if (state == GameState.point)
        {
            if (numberOfwhiteCoinsCollected >= 210)
            {
                PlayerPrefs.SetString("winner", "black");
            }
        }
        else
        {
            if (numberOfwhiteCoinsCollected >= 9)
            {
                PlayerPrefs.SetString("winner", "black");
            }
        }
    }
    public void WhiteCoinCollected(GameObject collectedcoin) {
        collectedcoin.SetActive(false);
        collectedcoin.GetComponent<CircleCollider2D>().isTrigger = true;
        collectedcoin.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        woffset = 0.3f * numberOfwhiteCoinsCollected;
        collectedcoin.transform.position = new Vector2(collectwhitepos.position.x + woffset, collectwhitepos.position.y);
        if (state == GameState.point)
        {
            numberOfwhiteCoinsCollected += 10;
        }
        else
        {
            numberOfwhiteCoinsCollected += 1;
        }
        carrywhite = collectedcoin;
        white.text = numberOfwhiteCoinsCollected.ToString();
        if (state == GameState.point)
        {
            if (numberOfwhiteCoinsCollected >= 210)
            {
                PlayerPrefs.SetString("winner", "white");
            }
        }
        else
        {
            if (numberOfwhiteCoinsCollected >= 9)
            {
                PlayerPrefs.SetString("winner", "white");
            }
        }
    }
    public void Fine(string which){
      if(which == "black"&&numberOfCoinsCollected >0){
        carryblack.GetComponent<CircleCollider2D>().isTrigger = false;
        //carryblack.transform.position = new Vector2(resetblack.position.x,resetblack.position.y);
        numberOfCoinsCollected -= 1;
        black.text = numberOfCoinsCollected.ToString();
      }
      else if(which == "white"&&numberOfwhiteCoinsCollected>0){
        carrywhite.GetComponent<CircleCollider2D>().isTrigger = false;
       // carrywhite.transform.position = new Vector2(resetwhite.position.x,resetwhite.position.y);
        numberOfwhiteCoinsCollected -=1;
        white.text = numberOfwhiteCoinsCollected.ToString();
      }
      else if(which == "blackqueen"&&numberOfCoinsCollected >0){
        carryblack.GetComponent<CircleCollider2D>().isTrigger = false;
        //carryblack.transform.position = new Vector2(resetqueen.position.x,resetqueen.position.y);
        numberOfCoinsCollected -= 1;
        black.text = numberOfCoinsCollected.ToString();
      }
      else if(which == "whitequeen"&&numberOfwhiteCoinsCollected>0){
        carrywhite.GetComponent<CircleCollider2D>().isTrigger = false;
        //carrywhite.transform.position = new Vector2(resetqueen.position.x,resetqueen.position.y);
        numberOfwhiteCoinsCollected -=1;
        white.text = numberOfwhiteCoinsCollected.ToString();
      }
    }
}
