using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SaleEnemy1Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy2Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy3Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy4Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy5Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy6Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy7Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy8Prefab = null;
    [SerializeField]
    private GameObject SaleEnemy9Prefab = null;
    private int spawnNumber1;
    public float positionx;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnchooseenmey());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnchooseenmey()
    {
        yield return new WaitForSeconds(3f);
        while(true)
        {
             spawnNumber1 = Random.Range(0,8);
            if(spawnNumber1 == 0)
            {
                spawnSaleEnemy1();
            }
            else if(spawnNumber1 == 1)
            {
                spawnSaleEnemy2();
            }
            else if(spawnNumber1 == 2)
            {
                spawnSaleEnemy3();
            }
            else if(spawnNumber1 == 3)
            {
                spawnSaleEnemy4();
            }
            else if(spawnNumber1 == 4)
            {
                spawnSaleEnemy5();
            }
            else if(spawnNumber1 == 5)
            {
                spawnSaleEnemy6();
            }
            else if(spawnNumber1 == 6)
            {
                spawnSaleEnemy7();
            }
            else if(spawnNumber1 == 7)
            {
                spawnSaleEnemy8();
            }
            else
            {
                spawnSaleEnemy9();
            }








            yield return new WaitForSeconds(1f);
            spawnNumber1 = 0;
           
        }
    }
    private void spawnSaleEnemy1()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy1Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy2()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy2Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy3()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy3Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy4()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy4Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy5()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy5Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy6()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy6Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy7()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy7Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy8()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy8Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
     private void spawnSaleEnemy9()
    {
        positionx = Random.Range(-1.9f, 1.9f);
        Instantiate(SaleEnemy9Prefab, new Vector2(positionx, 4.85f), Quaternion.identity);
    }
}
