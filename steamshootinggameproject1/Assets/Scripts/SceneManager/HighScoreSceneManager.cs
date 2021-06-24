using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighScoreSceneManager : MonoBehaviour
{
    [SerializeField]
    private Text textHighScore = null;
    // Start is called before the first frame update
    void Start()
    {
        ///textHighScore.text = string.Format("최고 점수\n{0}",PlayerPrefs.GetInt("HIGHSCORE", 0));    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSceneBtn()
    {
        Debug.Log("A");
        switch (this.gameObject.name)
        {
            case "Backturn":
                SceneManager.LoadScene("StartScean");
                //main_canvas.Change();
                break;
            /*
            case "HighScore":
                SceneManager.LoadScene("HighScoreScene");
                //main_canvas.Change();
                break;
            case "GameExplanation":
                SceneManager.LoadScene("ExplanationScean");
                break;
            /* 
                case "GameExit":
                SceneManager.LoadScene("")
                break;
            */
        }
    }
}
