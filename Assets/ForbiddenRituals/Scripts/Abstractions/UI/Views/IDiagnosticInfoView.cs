#nullable enable

using KarenKrill.UI.Views.Abstractions;

namespace ForbiddenRituals.UI.Views.Abstractions
{
    public interface IDiagnosticInfoView : IView
    {
        public string FpsText { set; }
    }
}