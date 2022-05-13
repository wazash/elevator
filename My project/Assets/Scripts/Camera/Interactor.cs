using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float range = 2f;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range, interactableLayer))
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.OnInteract();
                } 
            }
            
        }
    }
}
 