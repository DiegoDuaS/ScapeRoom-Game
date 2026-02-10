using UnityEngine;

public class Button : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isPressed = false;

    [SerializeField] AudioClip buttonSound;

    void Start()
    {
         levelManager = FindFirstObjectByType<LevelManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isPressed) return;

        if (other.gameObject.CompareTag("Sphere"))
        {

            isPressed = true;

            AudioManager.Instance.PlaySFX(buttonSound);

            if (levelManager != null)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                levelManager.CoinCollect();
            }
           
        }  
    }
}