using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletWave", menuName = "TowerDefense/BulletWave")]
public class BulletWave : ScriptableObject
{
    [Header("Tracking & Spread")]
    //public float TrackingAimOffset = 0.0f;
    public float BaseBulletOffset = 0.0f;

    [Header("Firerate")]
    public float ReloadModifier = 1.0f;
    public float FireDelay = 1.0f;

    [Header("Waves")]
    public List<Bullet> Bullets = new List<Bullet>();
 

    public void Reset()
    {
        foreach (Bullet bullet in Bullets)
        {
            bullet.Reset();
        }
    }
}
