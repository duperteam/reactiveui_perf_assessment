// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace View.iOS
{
    [Register ("ItemViewCell")]
    partial class ItemViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ValueLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageView != null) {
                ImageView.Dispose ();
                ImageView = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }

            if (ValueLabel != null) {
                ValueLabel.Dispose ();
                ValueLabel = null;
            }
        }
    }
}