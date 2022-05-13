using System;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    [SerializeField] private int buttonNumber;

    public static event Action<int> OnButtonPressed;

    public void OnInteract()
    {
        ButtonPressed(buttonNumber);
    }

    private void ButtonPressed(int number)
    {
        OnButtonPressed?.Invoke(number);
        Debug.Log($"Button {number} pressed");
    }
}
