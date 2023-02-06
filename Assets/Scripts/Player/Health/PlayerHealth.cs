using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerType based;
    public PlayerType player;

    public int currentHealth;

    public HealthBar healthBar;

    public FamilyHolder familyMenu;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = player.health;
        healthBar.SetMaxHealth(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        based.DeathInherit(player);
        player.health = 0;
        familyMenu.players.Add(Instantiate(player));
        RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
