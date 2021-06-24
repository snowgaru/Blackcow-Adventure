using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParentSound : MonoBehaviour
{
    private GameManager gameManager = null;
    [SerializeField]
    private float fireRate = 0.5f;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private float speed = 7f;
    private float timer = 0f;
    public GameObject newBullet = null;
    public Vector3 diff; //= Vector2.zero;
    private float rotationZ = 0f;
    public Transform[] firePos;
    int ramdomposition=0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnPosition());
      
        
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
    private IEnumerator SpawnPosition()
    {
        yield return new WaitForSeconds(3f);
        while(true){
        ramdomposition = Random.Range(0,4);
        SpawnSoundOne(ramdomposition);
        yield return new WaitForSeconds(2f);
        }
        //ramdomposition = Random.Range(0,3);
        //SpawnSoundOne(ramdomposition);
        /*else if(ramdomposition == 1)
        {
            SpawnSoundTwo();
        }
        else if(ramdomposition == 2)
        {
            SpawnSoundThree();
        }
        else
        {
            SpawnSoundFour();
        }*/
    }
    
    private void SpawnSoundOne(int Random)
    {
                
        //transform.Translate(Vector2.left * 3f * Time.deltaTime);

        //timer += Time.deltaTime;
        //if(timer >= fireRate)
        //{
            //timer = 0f;
            newBullet = Instantiate(bulletPrefab, firePos[Random]);

            diff = new Vector2(gameManager.Player.transform.position.x - firePos[Random].position.x,gameManager.Player.transform.position.y - firePos[Random].position.y);
    
            diff.Normalize();

            rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            newBullet.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90f);
            newBullet.GetComponent<Rigidbody2D>().AddForce(diff*speed,ForceMode2D.Impulse);
            //newBullet.transform.SetParent(null);
        //}
    }

     
   

}
