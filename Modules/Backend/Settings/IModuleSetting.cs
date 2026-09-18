using System;
using calamity.Core.Buttons;

namespace calamity.Modules.Backend.Settings;

public interface IModSetting
{
    public Type ButtonType { get; }

    public void SetupAssociations(IButton button);
}