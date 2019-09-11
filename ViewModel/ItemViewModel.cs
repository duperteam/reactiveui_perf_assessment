using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ViewModel.Contract;

namespace ViewModel
{
    public class ItemViewModel : ReactiveObject, IItemViewModel
    {
        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        public ItemViewModel()
        {
            this.WhenActivated(disposables =>
            {
                var rand = new Random();
                this.Title = $"title-{rand.Next(0, 1000)}";

                Observable.Interval(TimeSpan.FromSeconds(rand.Next(1, 10)))
                          .Select(l => $"value-{l}")
                          .ObserveOn(RxApp.MainThreadScheduler)
                          .BindTo(this, t => t.Value)
                          .DisposeWith(disposables);
            });
        }

        [Reactive]
        public string Title { get; private set; }

        [Reactive]
        public string Value { get; private set; }
    }
}
