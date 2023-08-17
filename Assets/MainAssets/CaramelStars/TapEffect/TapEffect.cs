using UnityEngine.UI;
using UnityEngine.Rendering;
using System;
using System.IO;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [HideInInspector]public MainLine MainLine;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        MainLine = this.GetComponent<MainLine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainLine.start && !MainLine.Is_Stop && !MainLine.Over && !MainLine.isFall && !MainLine.Win && MainLine.canuse)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(Instantiate(Effect, new Vector3(MainLine.transform.position.x, MainLine.transform.position.y - 0.4f, MainLine.transform.position.z), new Quaternion(-0.7071068f, 0f, 0f, 0.7071068f)), 2f);
            }
        }
    }
}
