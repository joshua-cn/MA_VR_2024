using UnityEngine;
using UnityEngine.AI;

public class RaycastToSetDestinationWithLineRenderer : MonoBehaviour
{
    // Reference to the NavMeshAgent
    public NavMeshAgent navMeshAgent;
    public float rayDistance = 100f;
    public NavMeshController controller;

    // Layer mask to filter which objects the ray should hit
    public LayerMask raycastLayerMask;

    // LineRenderer to visualize the ray
    public LineRenderer lineRenderer;

    // Optional: For debugging, show the ray in the Scene view
    public bool debugRay = true;

    void Update()
    {
        // Call SetDestination in Update to continuously check for raycast hits if needed
        SetDestination();
    }

    public void SetDestination()
    {
        // Cast a ray from the current transform's position in the forward direction
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit, rayDistance, raycastLayerMask))
        {
            // If the ray hits something, set the NavMeshAgent's destination to the hit point
            navMeshAgent.SetDestination(hit.point);

            // Optional: Log the hit information
            Debug.Log("Ray hit: " + hit.collider.name + " at " + hit.point);

            // Update LineRenderer's start and end positions to visualize the ray
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, ray.origin);         // Start of the ray (from the transform)
                lineRenderer.SetPosition(1, hit.point);         // End of the ray (hit point)
            }
        }
        else
        {
            // If no hit, just draw the ray in the forward direction for the full rayDistance
            if (lineRenderer != null)
            {
                lineRenderer.SetPosition(0, ray.origin);         // Start of the ray (from the transform)
                lineRenderer.SetPosition(1, ray.origin + ray.direction * rayDistance);  // End of the ray (no hit)
            }
        }

        // Optional: Draw the ray for debugging in the Scene view
        if (debugRay)
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
        }
    }
}
