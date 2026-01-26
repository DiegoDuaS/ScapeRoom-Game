using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Estado del Juego")]
    [SerializeField] private float _coins = 0;
    [SerializeField] private float _lives = 3;
    
    private Vector3 currentRespawnPosition; 

    public float winCoins = 7;

    [Header("Objetos a controlar")]
    [SerializeField] private Open puertaNivel1; 
    [SerializeField] private Open puertaNivel2; 
    [SerializeField] private Open puertaNivel3; 
    [SerializeField] private Open puertaNivel4; 

    [Header("UI Victoria")]
    public GameObject winScreen;



    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            currentRespawnPosition = player.transform.position;
        }
    }

    // Obtener fichas (tambien sirve con botones)
    public void CoinCollect()
    {
        _coins++;
        CheckDoors(); 

        if (_coins >= winCoins)
        {
            GameWin();
        }
    }


    // Se llama cuando se toca el spawnpoint
    public void SetCheckpoint(Vector3 newPosition)
    {
        currentRespawnPosition = newPosition;
        _lives = 3; 
    }

    // Muerte en caso de que toque un deathzone
    public void InstantDeath(GameObject player)
    {
        _lives = 0;

        CharacterController cc = player.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
        }

        player.transform.position = currentRespawnPosition;


        if (cc != null)
        {
            cc.enabled = true;
        }

        _lives = 3; 
    }
    
    // Logica para abrir puertas 
    private void CheckDoors()
    {
        if (_coins >= 1 && puertaNivel1 != null) puertaNivel1.ActivarApertura();
        if (_coins >= 2 && puertaNivel2 != null) puertaNivel2.ActivarApertura();
        if (_coins >= 3 && puertaNivel3 != null) puertaNivel3.ActivarApertura();
        if (_coins >= 4 && puertaNivel4 != null) puertaNivel4.ActivarApertura();
    }

    //L Logica para gamewin
    public void GameWin()
    {

        if (winScreen != null)
        {

            winScreen.SetActive(true);

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}