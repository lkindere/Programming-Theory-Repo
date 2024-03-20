using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyMage : Enemy
{
    // POLYMORPHISM
    override protected void SetStats()
    {
        movementSpeed = 1.0f;
        attackRangeMin = 5.0f;
        attackRangeMax = 6.0f;
    }

    // POLYMORPHISM
    override protected GameObject[] GetAllTargets() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        GameObject[] flyingTargets = GameObject.FindGameObjectsWithTag("FlyingTarget");
        
        GameObject[] allTargets = new GameObject[targets.Length + flyingTargets.Length];

        for (int i = 0; i < targets.Length; ++i)
            allTargets[i] = targets[i];
        for (int i = 0; i < flyingTargets.Length; ++i)
            allTargets[targets.Length + i] = flyingTargets[i];
        
        return allTargets;
    }
}
