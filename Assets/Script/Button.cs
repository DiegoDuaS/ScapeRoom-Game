using UnityEngine;

public class Button : MonoBehaviour
{
    private LevelManager levelManager;
    private bool isPressed = false; 

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

            
            if (levelManager != null)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                levelManager.CoinCollect();
            }
           
        }  
    }
}