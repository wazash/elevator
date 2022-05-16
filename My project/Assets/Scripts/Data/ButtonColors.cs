using System;
using UnityEngine;

[Serializable]
public class ButtonColors
{
    [SerializeField] private Color active;
    public Color Active => active;

    [SerializeField] private Color inactive;
    public Color Inactive => inactive;

    [SerializeField] private Color standard;
    public Color Standard => standard;
}

