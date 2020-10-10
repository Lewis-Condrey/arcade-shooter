using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int health;
    private int currentHealth;

    public Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;;
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            spawner.killed = spawner.killed +1;
            EnemyDie();
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }

    void EnemyDie()
    {
        Destroy(gameObject);
    }
}
