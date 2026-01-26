using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            Respawn();
        }
    }

    // Hacer que la caja respawnee en su lugar en caso que el jugador la tire al vacio
    public void Respawn()
    {
        transform.SetParent(null);

        transform.position = initialPosition;
        transform.rotation = initialRotation;
        if (rb != null)
        {
            rb.isKinematic = false; 
            rb.linearVelocity = Vector3.zero;  
            rb.angularVelocity = Vector3.zero; 
        }
        
        Debug.Log("Objeto rescatado del vacío: " + gameObject.name);
    }
}