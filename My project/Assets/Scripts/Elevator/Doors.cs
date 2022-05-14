using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private ElevatorController elevator;
    [SerializeField] private float doorClosingDelay = 2f;
    private Animator animator;

    private bool isOpened = false;
    private bool isObjectBetween;

    private float blendValue;
    [SerializeField]private bool isRaising = false;
    public bool IsOpened { get { return isOpened; } set { IsOpened = value; } }

    private void Awake()
    {
        ElevatorPanelButton.OnButtonPressed += ElevatorPanelButton_OnButtonPressed;
    }
    private void OnDestroy()
    {
        ElevatorPanelButton.OnButtonPressed -= ElevatorPanelButton_OnButtonPressed;
    }

    private void ElevatorPanelButton_OnButtonPressed(int obj)
    {
        if(elevator.CurrentFloor == obj)
        {
            return;
        }

        CloseDoor();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        CloseDoor();
    }

    private void Update()
    {
        blendValue = isRaising ? blendValue += Time.deltaTime : blendValue -= Time.deltaTime;
        blendValue = Mathf.Clamp(blendValue, 0, 1);

        animator.SetFloat("Blend", blendValue);
    
        if(blendValue == 0)
        {
            isOpened = true;
        }
        else if (blendValue == 1)
        {
            isOpened = false;
        }
    }

    public void CloseDoor()
    {
        if (isObjectBetween)
        {
            Debug.LogWarning("Something is blocking door");
            return;
        }
        isRaising = false;
    }
    private IEnumerator CloseDoorWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        CloseDoor();
    }


    public void OpenDoor()
    {
        isRaising = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isObjectBetween = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isObjectBetween = false;

            StartCoroutine(CloseDoorWithDelay(doorClosingDelay));
        }
    }
}
