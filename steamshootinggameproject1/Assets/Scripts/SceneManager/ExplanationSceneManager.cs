using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplanationSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                Debug.Log("태영이뱃살");
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
