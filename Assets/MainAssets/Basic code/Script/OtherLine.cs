// To user: Sorry,the code is so long!

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OtherLine : MonoBehaviour
{
    public GameObject tail;
    public GameObject die_effect;
    public AudioClip die_sound;
    public GameObject jump_effect;
    [HideInInspector] public MainLine MainLine;
    public GameObject Camera;
    
    [HideInInspector] public bool isFall = true;
    public bool ifStart { get; private set; }
    [HideInInspector] public float Jump_Effect_Deviation = -0.9f;
    public int NowPercentage = 0;

    [HideInInspector] public Queue<GameObject> Way = new Queue<GameObject>();
    private GameObject Jump_Effect_temp;

    public bool No_Clip = false;
    public bool Is_Stop = false;
    public bool fly = false;
    [HideInInspector] public bool start = false;
    [HideInInspector] public bool Can_Tail = true;
    [HideInInspector] public bool Over = true;
    public bool canuse = true;

    [HideInInspector] public GameObject LineBody;
    [HideInInspector] public GameObject LastLineBody;
    [HideInInspector] public bool Pause = false;
    [HideInInspector] public bool keydown = false;
    
    public GameObject trigger;
    private int clicknum = 0;

    void Start()
    {
        LineBody = tail;
        ifStart = false;
    }

    private void OnGUI()
    {
        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.normal.textColor = Color.black;
        gUIStyle.fontSize = 30;
        Rect rect = new Rect(10f, 10f, 150f, 100f);
        MainLine = GameObject.FindObjectOfType<MainLine>();
        //GUI.Label(rect, clicknum.ToString(), gUIStyle);
    }
    void Update()
    {
        this.transform.position = new Vector3 (MainLine.transform.position.x, MainLine.transform.position.y - 2, MainLine.transform.position.z);
        CreateLineBody();
    }

    public void CreateLineBody()
    {
        LineBody = Instantiate(tail, this.transform.position, this.transform.rotation);
        if (LineBody != null)
        {
            LastLineBody = LineBody;
        }
        if (LastLineBody != null)
        {
            Way.Enqueue(LastLineBody);
        }
        if (Can_Tail)
        {
            LineBody.SetActive(true);
        }
        else
        {
            LineBody.SetActive(false);
        }
    }


    public bool isGrounded()
    {
        return Physics.Raycast(this.transform.position, Vector3.down, this.transform.localScale.y / 2 + 0.1f);
    }
    
    
}