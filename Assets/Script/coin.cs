using UnityEngine;

public class coin : MonoBehaviour
{
    private LevelManager levelManager;
    public float speed = 50f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         levelManager = FindFirstObjectByType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(0, 45 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelManager.CoinCollect();
            Destroy(gameObject);
        }  
    }
}
