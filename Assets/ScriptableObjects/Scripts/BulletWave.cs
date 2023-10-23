using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletWave", menuName = "TowerDefense/BulletWave")]
public class BulletWave : ScriptableObject
{
    [Header("How many angles should the bullet lead the target?")]
    public float TrackingAimOffset = 0.0f;
    [Header("How long from the last bulletwave to this one?")]
    public float FireDelay = 1.0f;
    [Header("All the bullets in this Wave:")]
    public List<Bullet> Bullets = new List<Bullet>();
 

    public void Reset()
    {
        foreach (Bullet bullet in Bullets)
        {
            bullet.Reset();
        }
    }
}
