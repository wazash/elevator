using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorPanelDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;

    private void Awake()
    {
        ElevatorButton.OnButtonPressed += ElevatorButton_OnButtonPressed;
    }

    private void ElevatorButton_OnButtonPressed(int number)
    {
        UpdateDisplayText(number);
    }

    private void UpdateDisplayText(int number)
    {
        displayText.text = number.ToString();
    }
}
