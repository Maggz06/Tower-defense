using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    [Header("Static Values")]
    public float SpawnDelay = 0.0f;
    [Header("Enemy Stats")]
    public int MaxHealth = 1;
    public int Damage = 1;
    public int MoneyOnKill = 0;
    public float MoveSpeed = 1.0f;

    [Header("Dynamic Values")]
    public int Health = 0;
    public Vector3 MovementDirection = Vector3.zero;

    public void Copy(Enemy aEnemyToCopy)
    {
        MaxHealth = aEnemyToCopy.MaxHealth;
        MoveSpeed = aEnemyToCopy.MoveSpeed;
        SpawnDelay = aEnemyToCopy.SpawnDelay;
        MoneyOnKill = aEnemyToCopy.MoneyOnKill;
        Damage = aEnemyToCopy.Damage;
    }
    public void Reset()
    {
        Health = MaxHealth;
        MovementDirection = Vector3.zero;
    }
}

public class EnemyWave : MonoBehaviour
{
    public List<EnemyBase> Enemies = new List<EnemyBase>();
    public Vector3 MovementDirection = Vector3.zero;
    public void Start()
    {
        var enemyComp = GetComponentsInChildren<EnemyBase>();
        foreach(EnemyBase enemyFound in enemyComp)
        {
            Enemies.Add(enemyFound);
        }
        foreach (EnemyBase enemy in Enemies)
        {
            enemy.Initialize(MovementDirection);
        }
    }
}

[System.Serializable]
public class EnemyWaveContainer 
{
    public List<string> WaveKey = new List<string>();
}

