using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyWarrior : Enemy
{
    // POLYMORPHISM
    override protected void SetStats()
    {
        movementSpeed = 3.0f;
        attackRangeMin = 1.0f;
        attackRangeMax = 2.0f;
    }
}
