using System.Collections;
using System.Collections.Generic;
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

        // Set the initial rotation of the graphics to match the bullet's forward direction
        myMeshRenderer.transform.rotation = Quaternion.LookRotation(MoveDirection);

        // Adjust the local scale based on the tag
        if (gameObject.CompareTag("BackwardBullet"))
        {
            myMeshRenderer.transform.localScale = new Vector3(myMeshRenderer.transform.localScale.x, myMeshRenderer.transform.localScale.y, -myMeshRenderer.transform.localScale.z);
        }
    }

    void Update()
    {
        // Move the bullet in its forward direction
        transform.Translate(MoveDirection * Time.deltaTime * BulletData.SpeedFactor, Space.World);

        // Update the rotation of the graphics to match the bullet's current forward direction
        myMeshRenderer.transform.rotation = Quaternion.LookRotation(MoveDirection);

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
