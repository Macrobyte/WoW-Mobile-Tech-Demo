using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyController : Character
{
    public static EnemyController Instance;




    private void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        currentResource = maxResource;
    }

    private void Start()
    {
        //Set the enemy's health to the max health
        
    }




}
