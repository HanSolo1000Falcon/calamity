using System;
using UnityEngine;

namespace calamity.Core.Buttons;

public class TogglableButton : MonoBehaviour, IButton
{
    public event Action<bool> OnToggleEvent;

    public bool Toggled
    {
        get;
        set
        {
            if (value == field)
            {
                return;
            }

            field = value;
            OnToggleEvent?.Invoke(field);
        }
    }

    public string ButtonText
    {
        get;
        set
        {
            if (value != field)
            {
                return;
            }

            field = value;
            // TODO: Add actual text changing
        }
    }
}