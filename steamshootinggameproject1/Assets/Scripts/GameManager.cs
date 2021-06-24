using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// 해야할꺼 체력이 없거나 돈이 없어서 죽었을때 게임오버   돈에게 닿으면 돈이 깎임    게임종료 누르면 게임 아웃 
public class GameManager : MonoBehaviour
{

    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    public PlayerMove Player { get; private set; }
    public PoolManager Pool {get; private set;}

    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textLife = null;


    public int score = 3000;
    [SerializeField]
    public int life = 3;
    
    bool IsPause;

    [SerializeField]
    public GameObject WaitScene = null;

    [SerializeField]
    public GameObject ShopList1 = null;

    private int highscore = 0;

    private PlayerMove PlayerMove = null;
    
    private SaleEnemy1Move saleEnemy1Move = null;
    [SerializeField]
    public float playerDamage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("HIGHSCORE", highscore);
        ShopList1.SetActive(false);
        WaitScene.SetActive(false);
        IsPause = false;
        UpdateUI();
        Pool = FindObjectOfType<PoolManager>();
        Player = FindObjectOfType<PlayerMove>();
        MinPosition = new Vector2(-1.9f, -4.55f);
        MaxPosition = new Vector2(1.9f, 4.55f);
        StartCoroutine(Wait120second());
        PlayerMove = FindObjectOfType<PlayerMove>();
        saleEnemy1Move = FindObjectOfType<SaleEnemy1Move>();
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
        Time.timeScale = 1;
        StartCoroutine(changescore());
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wait120second()
    {
        yield return new WaitForSeconds(160);
        SceneManager.LoadScene("StartScean");
    }

    public void UpdateUI()
    {
        textScore.text = string.Format("현재 돈 : {0}", score);
        textLife.text = string.Format("생명 : {0}", life);
        
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        /*if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
        }*/
        UpdateUI();
    }

    public IEnumerator changescore()
    {
        yield return new WaitForSeconds(160);
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
        }
    }

    public void LifeMinus()
    {
        life--;
        if(life<0)
        {
            SceneManager.LoadScene("NotHaveLife");
        }
        UpdateUI();
    }

    public void OnClickRetry()
    {
         WaitScene.SetActive(true);
        if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }
       
        
    }

    public void restart()
    {
         WaitScene.SetActive(false);
        if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }

    }

    public void Return()
    {
        SceneManager.LoadScene("StartScean");
    }

   public void shopbutton()
   {
       ShopList1.SetActive(true);
       if (IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }
   }

   public void shopreturn()
   {
       
        ShopList1.SetActive(false);
        if (IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }

   }

   public void lifeplus()
   {
       Debug.Log("aaaa");
       if(score >= 75000)
       {
           score = score - 75000;
           life = life + 1;
           UpdateUI();
       }
       else
       {
           return;
       }
   }

   public void bulletspeed()
   {
       if(score>=200000)
       {
           score = score - 200000;
           PlayerMove.fireRate = PlayerMove.fireRate * 0.75f;
           Debug.Log(PlayerMove.fireRate);
           UpdateUI();
       }
       else
       {
           return;
       }
   }

   public void bulletdamage()
   {
       if(score>=200000)
       {
           score = score - 200000;
           playerDamage = playerDamage + 0.5f;
           UpdateUI();
       }
       else
       {
           return;
       }
   }

   public void notHaveLifeBackground()
   {
       SceneManager.LoadScene("StartScean");
   }

   
}
