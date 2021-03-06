using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using UnityEngine.SceneManagement;

public class FacebookScript : MonoBehaviour
{
  public GameObject dash;
  public GameObject errorbox;
  public Text erromesege;
    private void Awake(){
      if(!FB.IsInitialized){
        FB.Init(() => {
          if(FB.IsInitialized)
             FB.ActivateApp();
          else
             print("error");
          },
          isGameShown =>
          {
            if (!isGameShown)
                Time.timeScale =0 ;
            else
                Time.timeScale= 1;
          });
      }
      else
        FB.ActivateApp();
    }
    public void FacebookLogin(){
      var permission = new List<string>() {"public_profile", "email", "user_friends"};
      FB.LogInWithReadPermissions(permission, AuthCallBack);
    }
    void AuthCallBack(IResult result){
      if (FB.IsLoggedIn){
        SceneManager.LoadScene("home");
      }
      else{
        erromesege.text = "unsuccessfull login";
        errorbox.SetActive(true);
      }
    }
    public void FacebookLogout(){
      FB.LogOut();
    }
    public void resolute(){
      errorbox.SetActive(false);
    }
    

}
