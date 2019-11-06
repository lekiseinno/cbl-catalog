using System;
using CBLPOS.iOS.Renderers;
using DLToolkit.Forms.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlowListViewInternalCell), typeof(FlowListViewInternalCellRenderer))]
namespace CBLPOS.iOS.Renderers
{
    // DISABLES FLOWLISTVIEW ROW HIGHLIGHT
    public class FlowListViewInternalCellRenderer : ViewCellRenderer
    {
        public override UIKit.UITableViewCell GetCell(Xamarin.Forms.Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
            tv.AllowsSelection = false;
            var cell = base.GetCell(item, reusableCell, tv);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;

            return cell;
        }
    }
}