﻿using System;
using System.Runtime.Remoting.Contexts;
using CBLPOS.Controls;
using CBLPOS.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace CBLPOS.iOS.Renderers
{
    class CustomSwitchRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);


            if (e.OldElement != null || e.NewElement == null) return;

            CustomSwitch s = Element as CustomSwitch;

            UISwitch sw = new UISwitch();
            sw.ThumbTintColor = s.SwitchThumbColor.ToUIColor();
            sw.OnTintColor = s.SwitchOnColor.ToUIColor();


            SetNativeControl(sw);

        }









    }
}
