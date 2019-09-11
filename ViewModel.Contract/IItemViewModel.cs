using System.ComponentModel;
using ReactiveUI;

namespace ViewModel.Contract
{
    public interface IItemViewModel : INotifyPropertyChanged, IActivatableViewModel
    {
        /// <summary>
        /// A title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// A value
        /// </summary>
        string Value { get; }
    }
}
