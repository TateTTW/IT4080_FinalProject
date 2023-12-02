using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public float health;
    public float fullHealth; 
    public UnityEvent onDeath;
    // Start is called before the first frame update

    void Awake()
    {
        if (health > fullHealth)
        {
            fullHealth = health;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }

    public void damage(float damage)
    {
        health -= damage;
    }
}
