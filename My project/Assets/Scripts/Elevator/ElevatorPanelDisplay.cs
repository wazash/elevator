using TMPro;
using UnityEngine;

public class ElevatorPanelDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private ElevatorController elevator;

    private void Awake()
    {
        elevator.OnFloorChanged += Elevator_OnFloorChanged;
    }
    private void OnDestroy()
    {
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

    private void UpdateDisplayText(int number)
    {
        displayText.text = number.ToString();
    }
}
