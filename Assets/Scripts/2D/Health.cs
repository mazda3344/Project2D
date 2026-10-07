using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    public UnityAction<float> HealthChanged;
    private bool isAlive;

    public bool IsAlive { get; internal set; }

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
        HealthChanged.Invoke(currentHealth);
    }

    private void CheckIsAlive()
    {
        if(currentHealth > 0)
            isAlive = true;
        else
            isAlive = false;
    }
    
}
