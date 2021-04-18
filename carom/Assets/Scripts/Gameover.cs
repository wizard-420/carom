using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    // Start is called before the first frame update
    public void Replay()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Gohome()
    {
      SceneManager.LoadScene("home");
    }
}
