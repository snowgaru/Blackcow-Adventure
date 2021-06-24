using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dead());
    }
    IEnumerator Dead(){
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
