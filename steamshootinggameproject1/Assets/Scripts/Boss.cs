using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    [SerializeField]
    protected int hp = 500;
    
    private SpriteRenderer spriteRenderer = null;
    private GameManager gameManager = null;
    private Vector2 bossPosition2;

    [SerializeField]
    private float speed = 3f;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveBoss());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletMove bulletMove = null;
        if (isDead) return;
        if (collision.CompareTag("PlayerBullet"))
        {
            hp--;
            Destroy (collision.gameObject);
            collision.GetComponent<BulletMove>();
            if (bulletMove != null) bulletMove.
                    Despawn();
            if(hp <= 0)
            {
                StartCoroutine(BossDead());
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

    private IEnumerator BossDead()
    {
            for (int i = 0; i < 8; i++)
                {
                    spriteRenderer.enabled = false;
                    yield return new WaitForSeconds(0.2f);
                    spriteRenderer.enabled = true;
                    yield return new WaitForSeconds(0.2f);
                }
            Destroy(gameObject);
    }
     

     private IEnumerator MoveBoss()
    {
        bossPosition2 = new Vector2(0f,2f);
        yield return new WaitForSeconds(1f);
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, bossPosition2, speed * Time.deltaTime);
    }
}
