using UnityEngine;
using UnityEngine.InputSystem;

public class PickupSystem : MonoBehaviour
{
    [Header("Configuración")]
    public float range = 5.0f;
    public LayerMask afectedLayers;
    public string tagA = "PlacementCube";
    public Color colorSelect = Color.yellow;

    [Header("Configuración Agarre")] 
    public Vector3 handSize = new Vector3(0.5f, 0.5f, 0.5f);

    [Header("Referencias")]
    public Camera myCamera;

    private Transform rightHand;    
    private GameObject pickedObject;    
    
    private GameObject lastSeenObject;
    private Color originalColorObject;
    
    private Vector3 originalScaleObject;

    [Header("AUDIO")]
    [SerializeField] AudioClip pickupClip;

    void Start()
    {
        GameObject manoObj = GameObject.FindGameObjectWithTag("RightHand");
        if (manoObj != null)
        {
            rightHand = manoObj.transform;
        }
    }

    void Update()
    {
        if (pickedObject == null)
        {
            DetectObjectBlock();
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (pickedObject != null)
            {
                DropObject();
            }
            else if (lastSeenObject != null)
            {
                PickUpObject(lastSeenObject);
            }
        }
    }

    // Logica para agarrar objeto
    void PickUpObject(GameObject objeto)
    {
        RestoreLastColor();

        pickedObject = objeto;

        originalScaleObject = pickedObject.transform.localScale; 

        // Desactivarle todo
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;  
            rb.useGravity = false; 
        }

        AudioManager.Instance.PlaySFX(pickupClip);
        // Se pega a la mano
        pickedObject.transform.SetParent(rightHand);
        pickedObject.transform.localPosition = Vector3.zero; 
        pickedObject.transform.localRotation = Quaternion.identity; 

        pickedObject.transform.localScale = handSize;
    }


    // Logica para soltar objeto
    void DropObject()
    {
        if (pickedObject == null) return;
        
        pickedObject.transform.SetParent(null);

  
        pickedObject.transform.localScale = originalScaleObject;

        // Se pone enfrente del jugador
        pickedObject.transform.position = transform.position + (transform.forward * 1.5f) + Vector3.up;

        pickedObject.transform.rotation = Quaternion.identity; 

        // Activarle todo despues de dejarlo
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        
            rb.linearVelocity = Vector3.zero; 
            rb.angularVelocity = Vector3.zero;
        }

        pickedObject = null;
    }

    void DetectObjectBlock()
    {
        Ray rayo = myCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit golpe;

        if (Physics.Raycast(rayo, out golpe, range, afectedLayers))
        {
            // Chocar con caja
            if (golpe.collider.CompareTag(tagA))
            {
                GameObject actualObject = golpe.collider.gameObject;

                if (actualObject != lastSeenObject)
                {
                    RestoreLastColor(); 
                    PaintObject(actualObject); 
                }
            }
            else // Chocar con otro objeto
            {
                RestoreLastColor(); 
            }
        }
        else // Chocar con aire
        {
            RestoreLastColor(); 
        }
    }

    void PaintObject(GameObject objeto)
    {
        Renderer ren = objeto.GetComponent<Renderer>();
        if (ren != null)
        {
            lastSeenObject = objeto;
            originalColorObject = ren.material.color;
            ren.material.color = colorSelect;
        }
    }

    void RestoreLastColor()
    {
        if (lastSeenObject != null)
        {
            Renderer ren = lastSeenObject.GetComponent<Renderer>();
            if (ren != null)
            {
                ren.material.color = originalColorObject;
            }
            lastSeenObject = null; 
        }
    }
}