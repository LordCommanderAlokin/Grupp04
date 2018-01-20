using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 50;

    public GameObject deathAnimation;

    public Slider healthBarSlider;
    public Canvas myCanvas;

    void Start()
    {
        healthBarSlider.maxValue = startHealth;
        healthBarSlider.minValue = 0;
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Update()
    {
        healthBarSlider.value = health;
        myCanvas.transform.rotation = Quaternion.identity;
    }

    /*public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }*/

    void Die()
    {
        PlayerStats.Faith += worth;

        GameObject effect = (GameObject)Instantiate(deathAnimation, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        EnemyWaves.EnemiesAlive--;
        if(EnemyWaves.instance.allEnemies.Contains(this.gameObject))
        {
            Debug.Log("Removing enemy");
        }
        EnemyWaves.instance.allEnemies.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
