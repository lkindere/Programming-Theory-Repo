using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject currentTarget;
    protected float movementSpeed;
    protected float attackRangeMin;
    protected float attackRangeMax;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 2.0f;
        attackRangeMin = 0.75f;
        attackRangeMax = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget();
        MoveToTarget();
        RotateTowardsTarget();
    }

    virtual protected void SetTarget() {
        currentTarget = FindClosestTarget(GetAllTargets());
    }

    protected virtual GameObject[] GetAllTargets() {
        return GameObject.FindGameObjectsWithTag("Target");
    }
    
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

    protected float GetSqrDistanceToTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (pos - targetPos).sqrMagnitude;
    }

    protected float GetDistanceToTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (pos - targetPos).magnitude;
    }

    virtual protected void MoveToTarget() {
        if (GetDistanceToTarget(currentTarget) > attackRangeMax)
            transform.position += movementSpeed * Time.deltaTime * GetDirectionToTarget(currentTarget);
        else if (GetDistanceToTarget(currentTarget) < attackRangeMin)
            transform.position += movementSpeed * Time.deltaTime * GetDirectionFromTarget(currentTarget);
    }

    protected void RotateTowardsTarget() {
        transform.right = GetDirectionToTarget(currentTarget);
    }

    protected Vector3 GetDirectionToTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (targetPos - pos).normalized;
    }

    protected Vector3 GetDirectionFromTarget(GameObject target, bool ignoreVertical = true) {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position;

        if (ignoreVertical) {
            pos.y = 0.0f;
            targetPos.y = 0.0f;
        }

        return (pos - targetPos).normalized;
    }
}
