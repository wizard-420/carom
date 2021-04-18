using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    public float MAX_SPEED = 300f;
    Rigidbody2D rigid;
    [SerializeField] Slider slide;
    Transform self;
    Vector2 dir;
    Vector3 world;
    public GameObject arrowdir;
    private readonly int speed = 100;
    bool striked = false;
    Vector2 start;
    [SerializeField] private LineRenderer lineRenderer;
    int c = 0;
    public Text turndisplay;
    public GameObject finished;
    public Text winneris;
    private float radius;


    //[SerializeField] private rotating gameBoard;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        start = transform.position;
        self = transform;
        //initial = arrowdir.transform.position;
        PlayerPrefs.SetString("turn", "player1");
        turndisplay.text = "Shoot " + PlayerPrefs.GetString("turn");
        PlayerPrefs.SetString("winner", "noone");
        PlayerPrefs.SetString("queen", "");

    }
    void Update()
    {
        string whois = PlayerPrefs.GetString("winner");
        if (whois == "black" || whois == "white")
        {
            finished.SetActive(true);
            if (whois == "black")
            {
                winneris.text = "Winner is " + "PLAYER 1";
            }
            else
            {
                winneris.text = "Winner is " + "PLAYER 2";
            }
        }
    }

    public void SetPosition(float newPosition)
    {
        self.position = new Vector2(newPosition, start.y);
       

    }

    void OnMouseDrag()
    {
        radius = 4.080534f;
        arrowdir.SetActive(true);
        world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = world - self.position;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        arrowdir.transform.eulerAngles = new Vector3(0, 0, angle - 180);
        radius = Mathf.Clamp(Mathf.Max(Mathf.Abs(dir.x), Mathf.Abs(dir.y)), 0.12441f, 1.043508f);
        DrawPolygon(50, radius, self.position, 0.02f, 0.02f);
        //Debug.Log(radius);
    }
    void OnMouseUp()
    {
        arrowdir.SetActive(false);
        lineRenderer.enabled = false;
        if (radius >= 0.2f)
        {
            Shoot();
        }

    }

    public void Reset()
    {
        string turn = PlayerPrefs.GetString("turn");
        slide.value = 0f;
        rigid.velocity = Vector2.zero;
        transform.position = new Vector3(0.1021953f, -0.54f, -0.1114116f);
        Vector2 direction = new Vector2(
            transform.position.x - arrowdir.transform.position.x,
            transform.position.y - arrowdir.transform.position.y
        );
        arrowdir.transform.up = direction;

        //set =false;
        //move = true;

        if (PlayerPrefs.GetString("queen") == "hitbywhite")
        {
            c += 1;
            if (c > 1)
            {
                PlayerPrefs.SetString("queen", "");
                GameManager.Instance.Fine("whitequeen");
                c = 0;
            }
        }
        if (PlayerPrefs.GetString("queen") == "hitbyblack")
        {
            c += 1;
            if (c > 1)
            {
                PlayerPrefs.SetString("queen", "");
                GameManager.Instance.Fine("blackqueen");
                c = 0;
            }
        }
        if (turn == "player1")
        {
            PlayerPrefs.SetString("turn", "player2");
            if (GameManager.Instance.state == GameManager.GameState.vs)
            {
                //gameBoard.FlipPlayer();
            }
        }
        else if (turn == "player2")
        {
            PlayerPrefs.SetString("turn", "player1");
            if (GameManager.Instance.state == GameManager.GameState.vs)
            {
                //gameBoard.FlipPlayer();
            }
        }
        else if (turn == "lockplayer1")
        {
            PlayerPrefs.SetString("turn", "player1");
        }
        else if (turn == "lockplayer2")
        {
            PlayerPrefs.SetString("turn", "player2");
        }

        turndisplay.text = "Shoot " + PlayerPrefs.GetString("turn");
        striked = false;


    }
    public void Shoot()
    {
        striked = true;
    }
    void FixedUpdate()
    {

        if (striked)
        {
            Vector2 dir = (world - transform.position).normalized * -1f;
            transform.GetComponent<Rigidbody2D>().velocity = dir * speed * radius;
            striked = false;
        }
        if (rigid.velocity.magnitude != 0 && rigid.velocity.magnitude <= 0.02f)
        {
            Reset();
        }
    }


    void DrawPolygon(int vertexNumber, float radius, Vector3 centerPos, float startWidth, float endWidth)
    {
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.loop = true;
        float angle = 2 * Mathf.PI / vertexNumber;
        lineRenderer.positionCount = vertexNumber;

        for (int i = 0; i < vertexNumber; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                       new Vector4(0, 0, 1, 0),
                                       new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, radius, 0);
            lineRenderer.SetPosition(i, centerPos + rotationMatrix.MultiplyPoint(initialRelativePosition));

        }

        lineRenderer.enabled = true;
    }

}
