using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyRogue : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        attackRangeMin = 5.0f;
        attackRangeMax = 10.0f;
    }

    void Update()
    {
        SetTarget();
        MoveToTarget();
        RotateTowardsTarget();
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
