using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody[] bodyParts;
    private Collider[] colliders;
    private Animator animator;
    private Rigidbody enemyRb;

    public bool isActive = false;
    public float forceMagnitude = 500f;

    private void Awake()
    {
        FetchReferences();
        enemyRb = GetComponent<Rigidbody>();
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

    /// <summary>
    /// Apply force on the enemy when hit by a ball
    /// </summary>
    /// <param name="hitPoint">The point of impact</param>
    /// <param name="hitDirection">The direction of the impact</param>
    public void AddForceOnEnemy(Vector3 hitPoint, Vector3 hitDirection)
    {
        if (enemyRb != null)
        {
            Debug.Log("Enemy hit - applying force");

            // Apply impulse force at the impact point
            enemyRb.AddForceAtPosition(
                hitDirection.normalized * forceMagnitude,
                hitPoint,
                ForceMode.Impulse
            );
        }
    }
}