using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyController : Character
{
    public float aggroRange;
    
    public LayerMask aggroLayer;


    private void Awake()
    {
        currentHealth = maxHealth;
        currentResource = maxResource;
    }


    private new void Update()
    {
        base.Update();
        HandleTargetDetection();
    }

    private void HandleTargetDetection()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, aggroRange, aggroLayer);

        foreach (var hit in hitColliders)
        {
            if (hit.tag == "Player")
            {
                SetTarget(hit.transform.gameObject.GetComponent<PlayerController>());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
