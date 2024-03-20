using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private float fullBarScale;

    private void Start() {
        currentHealth = maxHealth;
        fullBarScale = healthBar.transform.localScale.x;
    }

    private void UpdateHealthbar() {
        Vector3 scale = healthBar.transform.localScale;
        scale.x = (currentHealth / maxHealth) * fullBarScale;

        healthBar.transform.localScale = scale;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        UpdateHealthbar();
    }
}
