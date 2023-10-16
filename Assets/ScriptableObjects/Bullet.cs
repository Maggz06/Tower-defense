using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bullet
{
    [Header("Base & Apperance")]
    public string ModelKey = "";
    public Color ColorFactor = Color.white;
    [Header("Fire")]
    public float SpeedFactor = 1.0f;
    public float FireAngleOffset = 0.0f;
    public float FireDelay = 0.0f;
    [Header("Impact")]
    public float SizeFactor = 1.0f;
    public int ImpactDamage = 1;
    public int ImpactHealth = 1;

    public void Copy(Bullet aBulletToCopy)
    {
        ModelKey = aBulletToCopy.ModelKey;
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
