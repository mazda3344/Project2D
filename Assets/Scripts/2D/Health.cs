using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;
    public Image HP;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if(currentHealth > 0)
            isAlive = true;
        else
            isAlive = false;
    }

    void Update()
    {
        HP.fillAmount = currentHealth / maxHealth;

    }
    
}
