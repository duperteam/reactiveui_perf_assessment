using DynamicData;
using ReactiveUI;
using System;
using System.Reactive.Disposables;
using ViewModel;
using ViewModel.Contract;

namespace View.iOS
{
    public partial class ViewController : ReactiveViewController<IItemListViewModel>
    {
        public ViewController(IntPtr intPtr) : base(intPtr)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.ItemTableView.RegisterNibForCellReuse(ItemViewCell.Nib, ItemViewCell.Key);

            this.WhenActivated(disposables =>
            {
                this.Bind(this.ViewModel, vm => vm.ItemCount, v => v.ItemCountSlider.Value, v => (float)Convert.ToDouble(v), Convert.ToInt32)
                    .DisposeWith(disposables);

                this.OneWayBind(this.ViewModel, vm => vm.ItemCount, v => v.ItemCountLabel.Text, Convert.ToString)
                    .DisposeWith(disposables);

                this.WhenAnyValue(x => x.ViewModel.Items)
                     .BindTo<ItemViewModel, ItemViewCell>(this.ItemTableView, ItemViewCell.Key, 80, cell => cell.Initialize())
                     .DisposeWith(disposables);
            });

            this.ViewModel = new ItemListViewModel();
            this.ItemCountSlider.MinValue = this.ViewModel.MinItems;
            this.ItemCountSlider.MaxValue = this.ViewModel.MaxItems;
        }

    }
}