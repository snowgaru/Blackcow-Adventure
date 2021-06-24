using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentSound : MonoBehaviour
{
    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLimit();
    }
    private void CheckLimit()
    {
        if(transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Destroy(gameObject);
          
        }
        if (transform.position.x < gameManager.MinPosition.x -2f)
        {
            Destroy(gameObject);
           
        }
        if(transform.position.y > gameManager.MaxPosition.y + 2f)
        {
            Destroy(gameObject);
            
        }
        if (transform.position.x > gameManager.MaxPosition.x +2f)
        {
            Destroy(gameObject);
           
        }

    }
}
