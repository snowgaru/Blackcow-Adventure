using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    protected float speed = 20f;
    
    private GameManager gameManager = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        CheckLimit();
    }
    protected void CheckLimit()
    {
        if(transform.position.x < gameManager.MinPosition.x-2f)
        {
            Despawn();
        }
        if (transform.position.x > gameManager.MaxPosition.x+2)
        {
            Despawn();
        }
        if (transform.position.y < gameManager.MinPosition.y-5)
        {
            Despawn();
        }
        if (transform.position.y > gameManager.MaxPosition.y+5)
        {
            Despawn();
        }
    }
    public virtual void Despawn()
    {
        transform.SetParent(gameManager.Pool.transform, false);
        gameObject.SetActive(false);
    }
}
