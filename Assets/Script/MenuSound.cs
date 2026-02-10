using UnityEngine;

public class MenuSound : MonoBehaviour
{
    [Header("AUDIO")]
    [SerializeField] AudioClip ambienceClip;
    void Start()
    {
        AudioManager.Instance.PlayAmbience(ambienceClip);
    }

}
