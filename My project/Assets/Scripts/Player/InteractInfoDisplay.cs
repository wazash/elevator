using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractInfoDisplay : MonoBehaviour
{
    [SerializeField] private Interactor interactor;
    [SerializeField] private TMP_Text text;

    private void Update()
    {
        if (interactor.CanInteract)
        {
            text.text = $"LMB to {interactor.InteractableInfo}";
        }
        else
        {
            text.text = "";
        }
    }
}
