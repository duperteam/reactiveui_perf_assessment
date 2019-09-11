using System;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ViewModel
{
    public class ItemListViewModel : ReactiveObject, IActivatableViewModel
    {
        private readonly SourceList<ItemViewModel> _items;
        private readonly ReadOnlyObservableCollection<ItemViewModel> _readOnlyItems;

        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public ItemListViewModel()
        {
            this._items = new SourceList<ItemViewModel>();

            this._items.Connect()
                       .Bind(out this._readOnlyItems)
                       .Subscribe();

            this._items.Edit(updater =>
            {
                for (var i = 0; i < this.ItemCount; i++)
                {
                    updater.Add(new ItemViewModel());
                }
            });

            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(x => x.ItemCount)
                    .Throttle(TimeSpan.FromSeconds(1))
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(count =>
                    {
                        var countDiff = count - this._readOnlyItems.Count;
                        if (countDiff > 0)
                        {
                            this._items.Edit(updater =>
                            {
                                for (var i = 0; i < countDiff; i++)
                                {
                                    this._items.Add(new ItemViewModel());
                                }
                            });
                        }
                        else
                        {
                            this._items.Edit(updater =>
                            {
                                for (var i = 0; i < Math.Abs(countDiff); i++)
                                {
                                    this._items.RemoveAt(0);
                                }
                            });
                        }
                    })
                    .DisposeWith(disposables);
            });
        }

        public int MinItems => 10;
        public int MaxItems => 20000;

        [Reactive]
        public int ItemCount { get; set; } = 30;

        public ReadOnlyObservableCollection<ItemViewModel> Items => this._readOnlyItems;
    }
}
