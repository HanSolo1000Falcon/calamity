using System;
using calamity.Compat;
using calamity.Core.Buttons;

namespace calamity.Modules.Backend.Settings;

public class TogglableModuleSetting : IModuleSetting
{
    public Type ButtonType => typeof(TogglableButton);

    public event Action<bool> OnToggleEvent; 

    private readonly string _settingName;
    private bool _toggled;

    public void SetupAssociations(IButton button)
    {
        if (button.GetType() != ButtonType)
        {
            Logging.LogError($"Unexpectedly got the wrong {nameof(IButton)} inheritor.");
            return;
        }

        var togglableButton = (TogglableButton)button;
        togglableButton.Toggled = _toggled;
        togglableButton.ButtonText = _settingName;
        togglableButton.OnToggleEvent += toggled =>
        {
            _toggled = toggled;
            OnToggleEvent?.Invoke(_toggled);
        };
    }

    public TogglableModuleSetting(string settingName, bool toggledState = false)
    {
        _settingName = settingName;
        _toggled = toggledState;
    }
}