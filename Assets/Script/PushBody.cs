using UnityEngine;

public class PushBody : MonoBehaviour
{
    [Header("Configuración")]
    public float pushForce = 2.0f;
    public string tagA = "Sphere"; 

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.collider.CompareTag(tagA))
        {
            return;
        }

        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        
        body.linearVelocity = pushDir * pushForce; 
    }
}
