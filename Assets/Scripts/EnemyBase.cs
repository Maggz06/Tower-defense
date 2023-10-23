using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyBase : MonoBehaviour
{
    [Header("Enemy Data")]
    public Enemy EnemyData = new Enemy();
    [Header("Static References")]
    public TextMeshProUGUI EnemyHealth = null;
    public void Initialize(Vector3 aMovementDirection, Enemy aEnemyContainer = null)
    {
        if(aEnemyContainer != null)
        {
            EnemyData.Copy(aEnemyContainer);
        }
        EnemyData.Reset();
        EnemyData.MovementDirection = aMovementDirection.normalized;
    }

    public void ImpactDamage(int aDamageNr)
    {
        EnemyData.Health -= aDamageNr;
        if(EnemyData.Health < 0 )
        {
            GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney += EnemyData.MoneyOnKill;
            GameObject.Destroy(this.gameObject);
        }
    }
    void Awake()
    {
        GameManager.GlobalGameManager.AllEnemies.Add(this);
    }

    void Update()
    {
        transform.Translate(EnemyData.MovementDirection * Time.deltaTime * EnemyData.MoveSpeed);
  
    }

    void OnDisable()
    {
        GameManager.GlobalGameManager.AllEnemies.Remove(this);
    }
}
