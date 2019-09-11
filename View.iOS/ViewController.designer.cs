// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace View.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ItemCountLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider ItemCountSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ItemTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ItemCountLabel != null) {
                ItemCountLabel.Dispose ();
                ItemCountLabel = null;
            }

            if (ItemCountSlider != null) {
                ItemCountSlider.Dispose ();
                ItemCountSlider = null;
            }

            if (ItemTableView != null) {
                ItemTableView.Dispose ();
                ItemTableView = null;
            }
        }
    }
}