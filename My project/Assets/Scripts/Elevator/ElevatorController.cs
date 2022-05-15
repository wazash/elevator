using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [SerializeField] private int currentFloor = 0;
    [SerializeField] private Transform[] floorsPositions;
    [SerializeField] private Doors door;
    [SerializeField] private float speed = 2f;

    private int targetFloor;
    private float movingDistanceDelta = 0.05f;

    private bool isMoving = false;
    public bool IsMoving => isMoving;

    public event Action<int> OnFloorChanged;
    public event Action OnStartMoving;
    public event Action OnStopMoving;
     
    public int CurrentFloor { get { return currentFloor; } }

    private void Awake()
    {
        ElevatorPanelButton.OnButtonPressed += ElevatorButton_OnButtonPressed;
    }
    private void OnDestroy()
    {
        ElevatorPanelButton.OnButtonPressed -= ElevatorButton_OnButtonPressed;
    }

    private void ElevatorButton_OnButtonPressed(int floor)
    {
        targetFloor = floor;
    }

    private void FixedUpdate()
    {
        MoveElevator(targetFloor);
    }

    private void Update()
    {
        CheckCurrentFloor();
    }

    private void MoveElevator(int targetFloor)
    {
        if (!door.IsOpened)
        {
            return;
        }

        if (targetFloor < floorsPositions.Length /*&& currentFloor != targetFloor*/)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = new Vector3(transform.position.x, floorsPositions[targetFloor].position.y, transform.position.z);

            if(transform.position == endPos)
            {
                if (isMoving)
                {
                    Debug.Log("StopMoving");
                    OnStopMoving?.Invoke();
                    door.OpenDoor();
                }
                isMoving = false;
                currentFloor = targetFloor;
            }
            else
            {
                if (!isMoving)
                {
                    Debug.Log("StartMoving");
                    OnStartMoving?.Invoke();
                }
                isMoving = true;
                transform.position = Vector3.MoveTowards(startPos, endPos, movingDistanceDelta * speed);
            }
        }
    }

    private void CheckCurrentFloor()
    {
        for (int i = 0; i < floorsPositions.Length; i++)
        {
            float floorOffset = transform.position.y - floorsPositions[i].position.y;

            if (Mathf.Abs(floorOffset) < 0.1f && currentFloor != i)
            {
                currentFloor = i;
                Debug.Log($"Floor changed: {currentFloor}");
                OnFloorChanged?.Invoke(currentFloor);
            }
        }

    }
}
