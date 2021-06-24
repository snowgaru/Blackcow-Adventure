using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleEnemy7Move : MonoBehaviour
{
    [SerializeField]
    protected float speed = 3f;

    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
       void Update()
    {
        Move();
        CheckLimit();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void CheckLimit()
    {
        if(transform.position.y < gameManager.MinPosition.y)
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