using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : BulletMove
{
    protected override void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        CheckLimit();
    }
    public override void Despawn()
    {
        Destroy(gameObject);
    }
}
