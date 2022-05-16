using System;
using UnityEngine;

public class ElevatorPanelButton : MonoBehaviour, IInteractable
{
    [SerializeField] private int buttonNumber;
    [SerializeField] private bool isActive = true;

    public static event Action<int> OnButtonPressed;

    public void OnInteract()
    {
        if (isActive)
        {
            ButtonPressed(buttonNumber);
        }
    }

    private void ButtonPressed(int number)
    {
        OnButtonPressed?.Invoke(number);
    }
}
