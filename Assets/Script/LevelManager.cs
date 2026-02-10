using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

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
    public GameObject pointer;

    [Header("UI Pausa")]
    public GameObject pauseScreen;
    private bool isPaused = false;

    [Header("UI Checkpoint")]
    public GameObject checkpointScreen;

    [Header("AUDIO")]
    [SerializeField] AudioClip ambienceClip;
    [SerializeField] AudioClip checkPointClip;



    private void Start()
    {
        AudioManager.Instance.PlayAmbience(ambienceClip);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
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
        checkpointScreen.SetActive(true);
        AudioManager.Instance.PlaySFX(checkPointClip);
        currentRespawnPosition = newPosition;
        _lives = 3;

        StartCoroutine(DeactivateScreenTime(2.0f));
    }

    private IEnumerator DeactivateScreenTime(float tiempo)
    {
        // Espera el tiempo indicado
        yield return new WaitForSeconds(tiempo);

        // Desactiva la pantalla
        checkpointScreen.SetActive(false);
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
            pointer.SetActive(false);

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Logics para Pausa

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.pKey.wasPressedThisFrame)
        {
            // Evitamos pausar si ya ganaste
            if (winScreen != null && !winScreen.activeSelf)
            {
                TogglePause();
            }
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Congelar el juego
            pauseScreen.SetActive(true);
            pointer.SetActive(false); 
            
            // Liberar el mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
            pauseScreen.SetActive(false);
            pointer.SetActive(true);
            
            // Bloquear el mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}