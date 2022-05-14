using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElevatorPanelDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private ElevatorController elevator;

    private void Awake()
    {
        ElevatorPanelButton.OnButtonPressed += ElevatorButton_OnButtonPressed;
        elevator.OnFloorChanged += Elevator_OnFloorChanged;
    }
    private void OnDestroy()
    {
        ElevatorPanelButton.OnButtonPressed -= ElevatorButton_OnButtonPressed;
        elevator.OnFloorChanged -= Elevator_OnFloorChanged;
    }
    private void Start()
    {
        UpdateDisplayText(elevator.CurrentFloor);
    }

    private void Elevator_OnFloorChanged(int floorNumber)
    {
        UpdateDisplayText(floorNumber);
    }


    private void ElevatorButton_OnButtonPressed(int number)
    {
        //UpdateDisplayText(number);
    }

    private void UpdateDisplayText(int number)
    {
        displayText.text = number.ToString();
    }
}
