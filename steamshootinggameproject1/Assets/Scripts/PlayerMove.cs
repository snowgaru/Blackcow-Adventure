using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
   private float speed = 10f;
    [SerializeField]
    private Vector2 targetPos;
    [SerializeField]
    private Vector2 mousePos;

    [SerializeField]
    public float fireRate = 0.1f;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameManager gameManager = null;
    private bool isDamaged = false;
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private SaleEnemy1Move saleEnemy1Move = null;

    [SerializeField]
    private GameObject Sound;

    [SerializeField]
    private GameObject MoneyHit;
    void Start()
    {
        saleEnemy1Move = FindObjectOfType<SaleEnemy1Move>();
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.x = Mathf.Clamp(targetPos.x, gameManager.MinPosition.x, gameManager.MaxPosition.x);
            targetPos.y = Mathf.Clamp(targetPos.y, gameManager.MinPosition.y, gameManager.MaxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition,targetPos,speed * Time.deltaTime);
        }
    }
    private void MovePos()
    {
        mousePos = Input.mousePosition;
    }
     private IEnumerator Fire()
    {
        
        while(true)
        {
            SpawnOrInstantiate();
            yield return new WaitForSeconds(fireRate);
        }
    }
   private void SpawnOrInstantiate()
   {
       if(bulletPrefab == null) return;
       GameObject bullet = null;
       if(gameManager.Pool.transform.childCount > 0)
       {
           bullet = gameManager.Pool.transform.GetChild(0).gameObject;
           bullet.transform.SetParent(bulletPosition, false);
           bullet.transform.position = bulletPosition.position;
           bullet.SetActive(true);
       }
       else
       {
            bullet = Instantiate(bulletPrefab, bulletPosition);
            bullet.transform.position = bulletPosition.position;
       }
        bullet.transform.SetParent(null);
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDamaged) return;
        if(collision.CompareTag("ParentSound"))
        {
            StartCoroutine(WaitForSecond());
            if(gameManager.life < 1)
             {
                 SceneManager.LoadScene("NotHaveLife");
             }
        }
        if(collision.CompareTag("SaleEnemy"))
        {
            
            StartCoroutine(HitMoeny());
            Destroy(collision.gameObject);
             if(gameManager.score < 1)
             {
                 SceneManager.LoadScene("NotHaveMoney");
             }
             
        }
//        new WaitForSeconds(5f)
    }

    private IEnumerator HitMoeny()
    {
        Debug.Log("이건또왜안되미ㅣ");
        isDamaged = true;
        Instantiate(MoneyHit,transform.position,Quaternion.identity);
        gameManager.score = gameManager.score - 1000;
        gameManager.UpdateUI();
        for (int i = 0; i < 8; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        
        }
        isDamaged = false;
        yield return new WaitForSeconds(0.00001f);
    }
    private IEnumerator WaitForSecond()
    {   
        isDamaged = true;
        gameManager.LifeMinus();
        Instantiate(Sound,transform.position,Quaternion.identity);
        for (int i = 0; i < 8; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        
        }
        isDamaged = false;
    }
   
   
}
