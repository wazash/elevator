using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerChanger : MonoBehaviour
{
    [SerializeField] private Interactor interactor;

    [SerializeField] private Sprite defaultPointer;
    [SerializeField] private Sprite interactivePointer;

    private Image pointer;

    private void Start()
    {
        pointer = GetComponent<Image>();
    }

    private void Update()
    {
        if (interactor.CanInteract)
        {
            ChangePointer(pointer, interactivePointer);
        }
        else
        {
            ChangePointer(pointer, defaultPointer);
        }
    }

    public void ChangePointer(Image pointer, Sprite sprite)
    {
        pointer.sprite = sprite;
    }
}
