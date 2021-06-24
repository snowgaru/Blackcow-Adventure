using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PutESCManager : MonoBehaviour
{
    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSceneBtn()
    {
          Debug.Log("됬다");
         SceneManager.LoadScene("ShopScean");                   
    }

    public void BackturnBotton()
    {
        
        gameManager.restart();
        Debug.Log("됬냐");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);        
    }
}
