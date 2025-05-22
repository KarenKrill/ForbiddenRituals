#nullable enable

using System;

using KarenKrill.UI.Presenters.Abstractions;

namespace ForbiddenRituals.UI.Presenters.Abstractions
{
    using Views.Abstractions;

    public interface ISettingsMenuPresenter : IPresenter<ISettingsMenuView>
    {
        public event Action? Close;
    }
}
