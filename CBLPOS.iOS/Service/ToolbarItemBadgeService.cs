﻿//using CBLPOS.Service;
//using Xamarin.Forms;
//using CBLPOS.iOS.Utils;
//using Xamarin.Forms.Platform.iOS;



//namespace CBLPOS.iOS.Service
//{
//    public class ToolbarItemBadgeService : IToolbarItemBadgeService
//    {
//        public void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor)
//        {
//            Device.BeginInvokeOnMainThread(() =>
//            {
//                var renderer = Platform.GetRenderer(page);
//                if (renderer == null)
//                {
//                    renderer = Platform.CreateRenderer(page);
//                    Platform.SetRenderer(page, renderer);
//                }
//                var vc = renderer.ViewController;

//                var rightButtomItems = vc?.ParentViewController?.NavigationItem?.RightBarButtonItems;
//                var idx = page.ToolbarItems.IndexOf(item);
//                if (rightButtomItems != null && rightButtomItems.Length > idx)
//                {
//                    var barItem = rightButtomItems[idx];
//                    if (barItem != null)
//                    {
//                        barItem.UpdateBadge(value, backgroundColor.ToUIColor(), textColor.ToUIColor());
//                    }
//                }

//            });
//        }
//    }

//}
