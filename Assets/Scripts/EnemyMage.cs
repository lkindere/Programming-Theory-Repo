using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 3.0f;
        attackRangeMin = 2.0f;
        attackRangeMax = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        MoveToTarget();
        RotateTowardsTarget();
    }
}
