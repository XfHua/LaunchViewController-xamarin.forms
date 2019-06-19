using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using Xamarin.Forms;

namespace App428.iOS
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("UIViewController1")]
    public class UIViewController1 : UIViewController
    {
        public UIViewController1()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.

        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            int a = 0;

            UILabel label = new UILabel();
            label.Frame = new CoreGraphics.CGRect(100,150,100,50);
            View.Add(label);
            label.Font = UIFont.SystemFontOfSize(25);
            label.Text = new NSString(a.ToString());


            NSTimer.CreateScheduledTimer(1, true, (obj) =>
            {
                a++;
                label.Text = new NSString(a.ToString());
            });

            //triggerd aft
            NSTimer.CreateScheduledTimer(7, true, (obj) =>
            {
                MessagingCenter.Send<object, object>(this, "ShowMainScreen", null);
            });
        }
    }
}