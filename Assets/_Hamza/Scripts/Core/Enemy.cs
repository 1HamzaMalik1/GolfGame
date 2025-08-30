using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody[] bodyParts;
    private Collider[] colliders;
    private Animator animator;
    public bool isActive = false;

    private void Awake()
    {
        FetchReferences();
    }

    private void Update()
    {
        if (isActive)
        {
            isActive = false;
            SetRagdollState(true);
        }

    }
    private void FetchReferences()
    {
        bodyParts = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();
    }
    public void SetRagdollState(bool isRagdoll)
    {
        foreach (var rb in bodyParts)
        {
            rb.isKinematic = !isRagdoll;
        }

        foreach (var col in colliders)
        {
            col.enabled = isRagdoll;
        }

        if (animator != null)
        {
            animator.enabled = !isRagdoll;
        }
    }

    public void addForceOnEnemy()
    {
        Rigidbody enemyRb = gameObject.GetComponent<Rigidbody>();
        if (enemyRb != null)
        {
            Debug.Log("Hit enemy");
            Vector3 backwardForceDirection = (transform.position).normalized;
            // Define a fixed force magnitude
            float forceMagnitude = 500f; // Adjust this value as needed
            // Apply the consistent force in the backward direction from the player
            enemyRb.AddForce(backwardForceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }
}
