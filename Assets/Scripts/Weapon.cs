using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected Vector3 finalPosition;
    [SerializeField] protected Vector3 finalRotation;
    [SerializeField] protected float attackAnimationDuration = 0.5f;
    [SerializeField] protected float attackCooldown = 1.0f;
    protected Vector3 initialPosition;
    protected Vector3 initialRotation;
    protected float animationElapsedTime = 0.0f;
    protected bool isAttacking = false;
    public bool canAttack = true;

    virtual protected void Start() {
        initialPosition = transform.localPosition;
        initialRotation = transform.localEulerAngles;
    }

    virtual protected void Update() {
        if (!isAttacking)
            return;
        
        animationElapsedTime += Time.deltaTime;
        LerpWeaponAnimation();
    }

    // ABSTRACTION
    virtual protected void LerpWeaponAnimation() {
        float t = animationElapsedTime / attackAnimationDuration;
        if (t <= 0.5)
            t *= 2.0f;
        else 
            t = 2 - 2 * t;

        transform.localPosition = Vector3.Lerp(initialPosition, finalPosition, t);
        float x = Mathf.LerpAngle(initialRotation.x, finalRotation.x, t);
        float y = Mathf.LerpAngle(initialRotation.y, finalRotation.y, t);
        float z = Mathf.LerpAngle(initialRotation.z, finalRotation.z, t);
        transform.localEulerAngles = new Vector3(x, y, z);
    }
    
    // ABSTRACTION
    virtual public void Attack(GameObject target) {
        StartCoroutine(AttackDelay(target.GetComponent<Target>()));
        isAttacking = true;
        canAttack = false;
    }

    // ABSTRACTION
    virtual protected IEnumerator AttackDelay(Target target) {
        yield return new WaitForSeconds(attackAnimationDuration);

        target.TakeDamage(damage);
        isAttacking = false;
        animationElapsedTime = 0.0f;
        transform.localPosition = initialPosition;
        transform.localEulerAngles = initialRotation;

        StartCoroutine(AttackInterval());
    }

    // ABSTRACTION
    virtual protected IEnumerator AttackInterval() {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
