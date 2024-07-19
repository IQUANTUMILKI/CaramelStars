using UnityEngine.UI;
using UnityEngine.Rendering;
using System;
using System.IO;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using DancingLineFanmade.Level;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [HideInInspector]public Player MainLine;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        MainLine = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.GameState == GameStatus.Playing && !MainLine.Falling)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(Instantiate(Effect, new Vector3(MainLine.transform.position.x, MainLine.transform.position.y - 0.4f, MainLine.transform.position.z), new Quaternion(-0.7071068f, 0f, 0f, 0.7071068f)), 2f);
            }
        }
    }
}
