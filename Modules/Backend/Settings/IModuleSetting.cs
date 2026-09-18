using System;
using calamity.Core.Buttons;

namespace calamity.Modules.Backend.Settings;

public interface IModuleSetting
{
    public Type ButtonType { get; }

    public void SetupAssociations(IButton button);
}