using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    private int currentHealth;

    void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
