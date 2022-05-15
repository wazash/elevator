using UnityEngine;
using UnityEngine.Events;

public class DoorsButton : MonoBehaviour, IInteractable
{
    [SerializeField] private Doors door;

    public UnityEvent OnButtonClicked;

    public void OnInteract()
    {
        //ChangeDoorStatus();
        OnButtonClicked?.Invoke();
    }


}
