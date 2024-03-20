using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected GameObject weapon;
    protected Animator animator;
    protected GameObject currentTarget;
    protected float movementSpeed;
    protected float attackRangeMin;
    protected float attackRangeMax;
    
    virtual protected void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        SetStats();
    }

    // ABSTRACTION
    virtual protected void SetStats() {
        movementSpeed = 2.0f;
        attackRangeMin = 0.75f;
        attackRangeMax = 1.25f;
    }

    virtual protected void Update()
    {
        SetTarget();
        MoveToTarget();
        RotateTowardsTarget();
        Attack();
    }

    // ABSTRACTION
    virtual protected void Attack() {
        Weapon weaponScript = weapon.GetComponent<Weapon>();

        if (weaponScript.canAttack && WithinRange(currentTarget)) {
            weaponScript.Attack(currentTarget);
        }
    }

    // ABSTRACTION
    virtual protected void SetTarget() {
        currentTarget = FindClosestTarget(GetAllTargets());
    }

    // ABSTRACTION
    virtual protected GameObject[] GetAllTargets() {
        return GameObject.FindGameObjectsWithTag("Target");
    }
    
    // ABSTRACTION
    protected GameObject FindClosestTarget(GameObject[] targets) {
        GameObject closest = targets[0];
        float closestSqrtDistance = GetSqrDistanceToTarget(targets[0]);

        for (int i = 1; i < targets.Length; ++i) {
            float currentSqrtDistance = GetSqrDistanceToTarget(targets[i]);
            
            if (currentSqrtDistance < closestSqrtDistance) {
                closest = targets[i];
                closestSqrtDistance = currentSqrtDistance;
            }
        }

        return closest;
    }

    // ABSTRACTION
    protected float GetSqrDistanceToTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (pos - targetPos).sqrMagnitude;
    }

    // ABSTRACTION
    protected float GetDistanceToTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (pos - targetPos).magnitude;
    }

    // ABSTRACTION
    virtual protected void MoveToTarget() {
        if (GetDistanceToTarget(currentTarget) > attackRangeMax) {
            transform.position += movementSpeed * Time.deltaTime * GetDirectionToTarget(currentTarget);
            animator.SetBool("isRunning_b", true);
        }
        else if (GetDistanceToTarget(currentTarget) < attackRangeMin) {
            transform.position += movementSpeed * Time.deltaTime * GetDirectionFromTarget(currentTarget);
            animator.SetBool("isRunning_b", true);
        }
        else
            animator.SetBool("isRunning_b", false);
    }

    // ABSTRACTION
    protected void RotateTowardsTarget() {
        transform.right = GetDirectionToTarget(currentTarget);
    }

    // ABSTRACTION
    protected Vector3 GetDirectionToTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (targetPos - pos).normalized;
    }

    // ABSTRACTION
    protected Vector3 GetDirectionFromTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (pos - targetPos).normalized;
    }

    // ABSTRACTION
    virtual protected bool WithinRange(GameObject target) {
        return GetDistanceToTarget(currentTarget) < attackRangeMax;
    }
}
