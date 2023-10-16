using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [Header("Bullet Data")]
    public Bullet BulletData = new Bullet();
    [Header("Static References")]
    public MeshRenderer myMeshRenderer = null;
    [Header("Dynamic Values")]
    public Vector3 MoveDirection = Vector3.zero;
    private float lifeTime = 0.0f;
    public void Initialize(Bullet aBulletContainer)
    {
        BulletData.Copy(aBulletContainer);
        transform.localScale = new Vector3(transform.localScale.x * BulletData.SizeFactor, transform.localScale.y * BulletData.SizeFactor, transform.localScale.z * BulletData.SizeFactor);
        myMeshRenderer.material.color *= BulletData.ColorFactor;
    }

    void Update()
    {
        transform.Translate(MoveDirection * Time.deltaTime * BulletData.SpeedFactor);
        lifeTime += Time.deltaTime;
        if (lifeTime >= 100.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyCollider = other.gameObject.GetComponent<EnemyBase>();
        if (enemyCollider != null)
        {
            enemyCollider.ImpactDamage(BulletData.ImpactDamage);
            BulletData.ImpactHealth--;
            if (BulletData.ImpactHealth <= 0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
