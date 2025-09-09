using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    public float forceMultiplier = 5f; // Adjust for stronger reaction

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Get direction of impact
                Vector3 hitDirection = collision.contacts[0].point - transform.position;
                hitDirection = -hitDirection.normalized;

                // Apply force at impact point
                rb.AddForceAtPosition(hitDirection * forceMultiplier, collision.contacts[0].point, ForceMode.Impulse);
            }
        }
    }
}
