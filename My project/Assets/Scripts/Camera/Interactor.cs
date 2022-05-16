using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float range = 2f;
    private Camera mainCamera;

    private bool canInteract;
    public bool CanInteract => canInteract;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range, interactableLayer))
        {
            canInteract = true;

            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.OnInteract();
                } 
            }
            
        }
        else
        {
            canInteract = false;
        }
    }
}
 