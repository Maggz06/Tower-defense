using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [Header("Gun Data")]
    public List<GunBaseObject> Guns = new List<GunBaseObject>();
    [Header("Dynamic Values")]
    public int CurrentGun = 0;
    public int CurrentBullet = 0;
    public float BulletDelayTimer = 0.0f;
    public int CurrentWave = 0;
    public float WaveTimer = 0.0f;
    //public Vector3 FirePositionOffset = Vector3.zero;
    public EnemyBase LockedOnTargetEnemy = null;
    void Start()
    {
        foreach (GunBaseObject gun in Guns)
        {
            gun.Reset();
        }
    }

    public bool TryCalculateEnemyInRange()
    {
        bool returnValue = false;
        float shortestDist = float.MaxValue;
        EnemyBase lookAtEnemy = null;
        foreach(EnemyBase enemy in GameManager.GlobalGameManager.AllEnemies)
        {
            var distanceVector = enemy.transform.position - transform.position;
            if(distanceVector.magnitude < shortestDist)
            {
                lookAtEnemy = enemy;
                shortestDist = distanceVector.magnitude;
                foreach (GunBaseObject gun in Guns)
                {
                    if (gun.LockOnRange >= shortestDist)
                    {
                        LockedOnTargetEnemy = enemy;
                        returnValue = true;
                    }
                }
            }
        }
        if(lookAtEnemy != null)
        {
            transform.LookAt(lookAtEnemy.transform, Vector3.up);
        }
        return returnValue;
    }
    void Update()
    {
        if(TryCalculateEnemyInRange())
        {
            WaveTimer += Time.deltaTime;
            foreach (GunBaseObject gun in Guns)
            {
          
                if (WaveTimer >= gun.WavesPerCycle[CurrentWave].FireDelay)
                {
                    StartCoroutine(FireWave(gun));
                    CurrentWave++;
                    if(CurrentWave >= gun.WavesPerCycle.Count)
                    {
                        CurrentWave = 0;
                    }
                    WaveTimer -= gun.WavesPerCycle[CurrentWave].FireDelay;
                }
            }
        }
    }
    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
    private IEnumerator FireWave(GunBaseObject gun)
    {
        var currentWave = gun.WavesPerCycle[CurrentWave];
        while (currentWave.Bullets.Count > CurrentBullet)
        {
            var currentBullet = currentWave.Bullets[CurrentBullet];
           BulletDelayTimer += Time.deltaTime;

            if (BulletDelayTimer >= currentBullet.FireDelay)
            {
                var bulletSpawn = GameManager.GlobalGameManager.SpawnObject(currentBullet.SpawnKey.name, transform.position);
                var bulletComponent = bulletSpawn.GetComponent<BulletBase>();
                bulletComponent.Initialize(currentBullet);
                bulletComponent.MoveDirection = (LockedOnTargetEnemy.transform.position - transform.position).normalized;
                float rotationAngle = currentBullet.FireAngleOffset + currentWave.TrackingAimOffset;
                Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
                bulletComponent.MoveDirection = rotation * bulletComponent.MoveDirection;
                BulletDelayTimer -= currentBullet.FireDelay;
                CurrentBullet++;
            }
            yield return null;
        }
        CurrentBullet = 0;
        yield return null;

    }
}
