using UnityEngine;

public class Open : MonoBehaviour
{
    public float velocidad = 2.0f;
    private Vector3 finalPosition;
    private bool needsOpen = false;

    private AudioSource audioSource;

    void Start()
    {
        finalPosition = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);

        audioSource = GetComponent<AudioSource>();
    }

    public void ActivarApertura()
    {
        if (!needsOpen) 
        {
            needsOpen = true;

            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    void Update()
    {
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