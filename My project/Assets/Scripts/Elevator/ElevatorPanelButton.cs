using System;
using System.Collections;
using UnityEngine;

public class ElevatorPanelButton : MonoBehaviour, IInteractable
{
    [SerializeField] private int buttonNumber;
    [SerializeField] private bool isActive = true;

    [SerializeField] private ButtonColors color;

    private MeshRenderer meshRenderer;

    public static event Action<int> OnButtonPressed;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnInteract()
    {
        if (isActive)
        {
            ChangeButtonColor(color.Active);
            ButtonPressed(buttonNumber);
        }
        else
        {
            ChangeButtonColor(color.Inactive);
            StartCoroutine(ChangeInactiveColorBack(1f));
        }
    }

    private void ButtonPressed(int number)
    {
        OnButtonPressed?.Invoke(number);
    }

    public void ChangeButtonColor(Color color)
    {
        meshRenderer.material.color = color;
    }
    private IEnumerator ChangeInactiveColorBack(float time)
    {
        yield return new WaitForSeconds(time);
        ChangeButtonColor(color.Standard);
    }
}
