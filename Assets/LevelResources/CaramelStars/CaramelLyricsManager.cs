using System.Collections;
using System.Collections.Generic;
using DancingLineFanmade.Level;
using UnityEngine;
using UnityEngine.UI;

public class CaramelLyricsManager : MonoBehaviour
{
    [System.Serializable] public class Group
    {
        public string lyric;
        public int num;
        public float startTime;
        public float endTime;
        public Vector3 textPos;
        public Color32 color;
    }
    public Group[] lyricsGroup;
    public CaramelLyricsHolder[] lyricHolders;
    // private MainLine _line;
    private Player line;

    void Start()
    {
        // _line = GameObject.FindObjectOfType<MainLine>();
        line = Player.Instance;
    }

    void Update()
    {
        for(int i = 0;i <= lyricsGroup.Length - 1;i++)
        {
            if(line.SoundTrack.time >= lyricsGroup[i].startTime && line.SoundTrack.time <= lyricsGroup[i].endTime && !lyricHolders[lyricsGroup[i].num - 1].IsUsing)
            {
                Debug.Log("SetLyrics");
                StartCoroutine(lyricHolders[i].ShowLyric(lyricsGroup[i].lyric , lyricsGroup[i].startTime , lyricsGroup[i].endTime , lyricsGroup[i].textPos , lyricsGroup[i].color));
            }
        }
    }
}
