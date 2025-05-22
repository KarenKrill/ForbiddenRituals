#nullable enable

using System;

using KarenKrill.UI.Views.Abstractions;

namespace ForbiddenRituals.UI.Views.Abstractions
{
    public interface ISettingsMenuView : IView
    {
        #region Graphics

        #endregion

        #region Diagnostic
        bool ShowFps { get; set; }
        #endregion

        event Action? Apply;
        event Action? Cancel;
    }
}