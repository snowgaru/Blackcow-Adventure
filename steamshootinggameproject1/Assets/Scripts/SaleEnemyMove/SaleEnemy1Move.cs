using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaleEnemy1Move : MonoBehaviour
{
    [SerializeField]
    protected float speed = 3f;

    [SerializeField]
    protected float hp = 5;
    
    [SerializeField]
    public int point = 1000;
    

    private bool isDamaged = false;
    private bool isDead = false;
    private Collider2D col = null;
    private GameManager gameManager = null;
    [SerializeField]
    private GameObject Sound;
    void Start()
    {
        
        col = GetComponent<Collider2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        Move();
        CheckLimit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletMove bulletMove = null;
        if (isDead) return;
        if (collision.CompareTag("PlayerBullet"))
        {
            hp = hp-gameManager.playerDamage;
            Destroy (collision.gameObject);
            collision.GetComponent<BulletMove>();
            if (bulletMove != null) bulletMove.
                    Despawn();
            if(hp <= 0)
            {
                gameManager.AddScore(point);
                Instantiate(Sound,transform.position,Quaternion.identity);
                Destroy(gameObject);
                /*if (isDamaged) return;
                isDamaged = true;
                ///StartCoroutine(Damaged());
                return;*/
            }
            
            //isDead = true;
            ///gameManager.AddScore(score);
            ///StartCoroutine(Dead());
        }
    }
    protected virtual void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void CheckLimit()
    {
        if(transform.position.y < gameManager.MinPosition.y - 4)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < gameManager.MinPosition.x -2f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > gameManager.MaxPosition.x +2f)
        {
            Destroy(gameObject);
        }

    }
}
