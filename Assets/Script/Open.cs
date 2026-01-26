using UnityEngine;

public class Open : MonoBehaviour
{
    public float velocidad = 2.0f; 
    private Vector3 finalPosition; 
    private bool needsOpen = false;

    void Start()
    {
        finalPosition = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
    }

    public void ActivarApertura()
    {
        needsOpen = true;
    }

    void Update()
    {
        // Animacion para abrir las puertas
        if (needsOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPosition, velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, finalPosition) < 0.001f)
            {
                Destroy(gameObject);
            }
        }
    }
}