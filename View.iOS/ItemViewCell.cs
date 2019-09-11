using System;
using System.Reactive.Disposables;
using Foundation;
using ReactiveUI;
using UIKit;
using ViewModel.Contract;

namespace View.iOS
{
    public partial class ItemViewCell : ReactiveTableViewCell<IItemViewModel>
    {
        public static readonly NSString Key = new NSString("ItemViewCell");
        public static readonly UINib Nib = UINib.FromName("ItemViewCell", NSBundle.MainBundle);

        protected ItemViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Title, v => v.TitleLabel.Text)
                    .DisposeWith(disposables);

                this.OneWayBind(this.ViewModel, vm => vm.Value, v => v.ValueLabel.Text)
                    .DisposeWith(disposables);
            });
        }

        public void Initialize()
        {
        }
    }
}
