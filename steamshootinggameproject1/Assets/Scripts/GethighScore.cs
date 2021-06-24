using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GethighScore : MonoBehaviour
{
    public Text text;
    public int highscore;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HIGHSCORE");
        text.text = string.Format("{0}",highscore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
