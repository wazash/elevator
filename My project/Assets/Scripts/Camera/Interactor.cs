using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float range = 2f;
    private Camera mainCamera;

    private bool canInteract;
    public bool CanInteract => canInteract;
    private string interactableInfo;
    public string InteractableInfo => interactableInfo;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range, interactableLayer))
        {
            if(hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                canInteract = true;
                interactableInfo = interactable.Info;
                if (Input.GetButtonDown("Fire1"))
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
 