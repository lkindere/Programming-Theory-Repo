using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class WeaponMagic : Weapon
{
    [SerializeField] private GameObject magicEffect;
    private Vector3 targetPosition;

    // POLYMORPHISM
    override protected void Update()
    {
        if (!isAttacking)
            return;

        animationElapsedTime += Time.deltaTime;
        LerpWeaponAnimation();
    }

    // POLYMORPHISM
    override public void Attack(GameObject target) {
        targetPosition = target.transform.position;
        SpawnMagicEffect();
        StartCoroutine(AttackDelay(target.GetComponent<Target>()));
        isAttacking = true;
        canAttack = false;
    }

    // ABSTRACTION
    private void SpawnMagicEffect() {
        GameObject effect = Instantiate(magicEffect, targetPosition, magicEffect.transform.rotation);
        StartCoroutine(DestroyMagicInstance(effect));
    }

    // ABSTRACTION
    private IEnumerator DestroyMagicInstance(GameObject magicEffectInstance) {
        yield return new WaitForSeconds(attackAnimationDuration);

        Destroy(magicEffectInstance);
    }
}
