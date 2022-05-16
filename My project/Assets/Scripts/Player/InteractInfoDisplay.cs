using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractInfoDisplay : MonoBehaviour
{
    [SerializeField] private Interactor interactor;
    [SerializeField] private TMP_Text text;

    private const string INFO_TEXT = "LMB to interact";

    private void Update()
    {
        if (interactor.CanInteract)
        {
            text.text = INFO_TEXT;
        }
        else
        {
            text.text = "";
        }
    }
}
