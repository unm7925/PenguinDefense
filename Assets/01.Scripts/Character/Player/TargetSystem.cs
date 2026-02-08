using System.Collections.Generic;
using UnityEngine;
public class TargetSystem:MonoBehaviour
{
    private readonly List<Enemy> targets = new();
    
    public void Register(Enemy enemy)
    {
        if (!targets.Contains(enemy))
            targets.Add(enemy);
    }

    public void Unregister(Enemy enemy)
    {
        targets.Remove(enemy);
    }

    public Enemy GetClosesTarget(Vector2 from)
    {
        Enemy closest = null;
        float minDist = float.MaxValue;

        foreach (var enemy in targets)
        {
            if(!enemy.gameObject.activeInHierarchy) continue;

            float dist = Vector2.Distance(from, enemy.transform.position);

            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy;
            }
        }

        return closest;
    }
}
