using System.Collections;
using UnityEngine;

public class WeaponRanged : Weapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Sprite[] weaponSprites;

    // POLYMORPHISM
    override protected void Update()
    {
        if (!isAttacking)
            return;

        animationElapsedTime += Time.deltaTime;
        LerpWeaponAnimation();
    }

    override protected void LerpWeaponAnimation() {
        float t = animationElapsedTime / attackAnimationDuration;
        if (t <= 0.5)
            t *= 2.0f;
        else 
            t = 2 - 2 * t;

        int currentSprite = Mathf.RoundToInt(t * (weaponSprites.Length - 1));
        GetComponent<SpriteRenderer>().sprite = weaponSprites[currentSprite];
    }

    override public void Attack(GameObject target) {
        StartCoroutine(AttackDelay(target.GetComponent<Target>()));
        StartCoroutine(SpawnProjectile(target));
        isAttacking = true;
        canAttack = false;
    }

    private IEnumerator SpawnProjectile(GameObject target) {
        yield return new WaitForSeconds(attackAnimationDuration * 0.8f);

        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        MoveProjectile moveProjectile = projectile.GetComponent<MoveProjectile>();

        Vector3 control = Vector3.Lerp(transform.position, target.transform.position, 0.5f);
        control.y += 5.0f;

        moveProjectile.targetPos = target.transform.position;
        moveProjectile.controlPos = control;
    }
}
