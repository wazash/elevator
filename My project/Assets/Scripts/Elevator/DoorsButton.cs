using UnityEngine;
using UnityEngine.Events;

public class DoorsButton : MonoBehaviour, IInteractable
{
    [SerializeField] private Doors door;

    public UnityEvent OnButtonClicked;

    [SerializeField] private string info;
    public string Info => info;

    public void OnInteract()
    {
        OnButtonClicked?.Invoke();
    }
}
