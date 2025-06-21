using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tracks all enemy units present in the scene.
/// </summary>
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private readonly List<HealthComponent> enemies = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// Registers a new enemy so it can be tracked.
    /// </summary>
    public void RegisterEnemy(HealthComponent enemy)
    {
        if (enemy == null || enemies.Contains(enemy))
            return;

        enemies.Add(enemy);
        enemy.OnDeath += () => enemies.Remove(enemy);
    }

    /// <summary>
    /// Returns true when all registered enemies are dead or missing.
    /// </summary>
    public bool AreAllDead()
    {
        enemies.RemoveAll(e => e == null);

        if (enemies.Count == 0)
            return false;

        foreach (var e in enemies)
        {
            if (e.IsAlive)
                return false;
        }
        return true;
    }
}
