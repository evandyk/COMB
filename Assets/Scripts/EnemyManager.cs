using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();
    
    public void AddEnemy(Enemy e)
    {
        enemiesInTrigger.Add(e);
    }

    public void RemoveEnemy(Enemy e)
    {
        enemiesInTrigger.Remove(e);
    }
}
