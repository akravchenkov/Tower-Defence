using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    private bool isDead = false;

    [Header("Unity Stuff")]
    public Image healthBar;


	// Use this for initialization
	void Start () {
        health = startHealth;
	}

    public void TakeDamage (float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die ()
    {
        isDead = true;

        PlayerStats.Money += worth;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


}
