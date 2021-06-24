using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceanManager : MonoBehaviour
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
            case "GameStart":
              
                SceneManager.LoadScene("SampleScene");
                //main_canvas.Change();
                break;
            case "HighScore":
                SceneManager.LoadScene("HighScoreScene");
                //main_canvas.Change();
                break;
            case "GameExplanation":
                SceneManager.LoadScene("ExplanationScean");
                break;
            case "GameExit":
                Debug.Log("A");
                Application.Quit();
                break;
            
        }
    }
}
