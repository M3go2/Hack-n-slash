using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float power = 10;
    public int killScore = 200;

    [SerializeField] private Image healthBar; // Reference to the health bar image
    [SerializeField] private TextMeshProUGUI healthText; // Reference to the health text

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        // Initialize health bar and text if references are provided
        if (healthBar != null)
        {
            healthBar.fillAmount = 1f;
        }
        if (healthText != null)
        {
            UpdateHealthText();
        }
    }

    public void ChangeHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);

        Debug.Log("Current Health: " + currentHealth + "/" + maxHealth);

        // Update health bar and text if references are provided
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        if (healthText != null)
        {
            UpdateHealthText();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = string.Format("{0:0.##}%", (currentHealth / maxHealth) * 100);
    }

    private void Die()
    {
        if (transform.CompareTag("Player"))
        {
            // Game over logic
        }
        else if (transform.CompareTag("Enemy"))
        {
            LevelManager.Instance.score += killScore;
            Destroy(gameObject);
            Instantiate(LevelManager.Instance.particles[2], transform.position, transform.rotation);
        }
    }
}