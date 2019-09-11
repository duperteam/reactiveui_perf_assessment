using System.Collections.ObjectModel;
using System.ComponentModel;
using ReactiveUI;

namespace ViewModel.Contract
{
    public interface IItemListViewModel : INotifyPropertyChanged, IActivatableViewModel
    {
        /// <summary>
        /// Minimun count of items possible in the <see cref="Items"/> collection
        /// </summary>
        int MinItems { get; }

        /// <summary>
        /// Maximum count of items possible in the <see cref="Items"/> collection
        /// </summary>
        int MaxItems { get; }

        /// <summary>
        /// Count of items possible in the <see cref="Items"/> collection.
        /// Changing the value will update the <see cref="Items"/> collection accordingly.
        /// </summary>
        int ItemCount { get; set; }

        ReadOnlyObservableCollection<IItemViewModel> Items { get; }
    }
}
