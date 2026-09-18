using System;
using UnityEngine;

namespace calamity.Core.Buttons;

public class TogglableButton : MonoBehaviour, IButton
{
    public event Action<bool> OnToggleEvent;

    private bool _toggled;
    public bool Toggled
    {
        get => _toggled;
        set
        {
            if (value == _toggled)
            {
                return;
            }

            _toggled = value;
            OnToggleEvent?.Invoke(_toggled);
        }
    }

    private string _buttonText;
    public string ButtonText
    {
        get => _buttonText;
        set
        {
            if (value != _buttonText)
            {
                return;
            }

            _buttonText = value;
            // TODO: Add actual text changing
        }
    }
}