using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyWarrior : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        attackRangeMin = 1.0f;
        attackRangeMax = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        MoveToTarget();
        RotateTowardsTarget();
    }
}
