using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunBase", menuName = "TowerDefense/Gun")]
public class GunBaseObject : ScriptableObject
{
    [Header("Gun Characteristics")]
    public float LockOnRange = 10.0f;
    [Header("Waves")]
    public List<BulletWave> WavesPerCycle = new List<BulletWave>();




    public void Reset()
    {
   
        foreach (BulletWave wave in WavesPerCycle)
        {
            wave.Reset();
        }
    }
}
