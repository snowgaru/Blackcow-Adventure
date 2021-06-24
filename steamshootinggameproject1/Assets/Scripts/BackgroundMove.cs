using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    Material myMaterial;

    public MeshRenderer mesh = null;

    private Vector2 offset = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(mesh == null) return;
        offset.y += speed * Time.deltaTime;
        mesh.material.SetTextureOffset("_MainTex", offset);
    }
}
