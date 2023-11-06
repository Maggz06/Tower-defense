using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
    [Header("Base & Apperance")]
    public GameObject SpawnKey = null;
    public Color ColorFactor = Color.white;
    [Header("How Fast is the bullet?")]
    public float SpeedFactor = 1.0f;
    [Header("How many degrees should the bullet offset from the original aim direction?")]
    public float FireAngleOffset = 0.0f;
    [Header("How much time should pass between the last bullet and this one?")]
    public float FireDelay = 0.0f;
    [Header("How Big is the bullet?")]
    public float SizeFactor = 1.0f;
    [Header("How much damage does the bullet do?")]
    public int ImpactDamage = 1;
    [Header("How many times can the bullet hit an enemy?")]
    public int ImpactHealth = 1;

    public void Copy(Bullet aBulletToCopy)
    {
        SpawnKey = aBulletToCopy.SpawnKey;
        ColorFactor = aBulletToCopy.ColorFactor;
        SpeedFactor = aBulletToCopy.SpeedFactor;
        FireAngleOffset = aBulletToCopy.FireAngleOffset;
        FireDelay = aBulletToCopy.FireDelay;
        SizeFactor = aBulletToCopy.SizeFactor;
        ImpactDamage = aBulletToCopy.ImpactDamage;
        ImpactHealth = aBulletToCopy.ImpactHealth;
    }
    public void Reset()
    {

    }

}
