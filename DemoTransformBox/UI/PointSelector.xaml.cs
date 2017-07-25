using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoTransformBox.UI
{
    public partial class PointSelector : UserControl
    {
        #region SelectedPoint

        public event EventHandler<SelectedPointEventArgs> SelectedPoint;

        private void OnSelectedPoint(TransformPoint transformPoint)
        {
            if (SelectedPoint != null)
            {
                SelectedPoint(this, new SelectedPointEventArgs(transformPoint));
            }
        }

        #endregion

        public PointSelector()
        {
            InitializeComponent();

            TransformPoint point = TransformPoint.CentralPoint;

            OnSelectedPoint(point);
            UpdateSelectedTransformPoint(point.ToString());
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            FrameworkElement source = e.OriginalSource as FrameworkElement;

            if (source != null)
            {
                TransformPoint point;

                if (Enum.TryParse(source.Name, out point))
                {
                    OnSelectedPoint(point);
                    UpdateSelectedTransformPoint(point.ToString());
                }
            }
        }

        private void UpdateSelectedTransformPoint(String pointName)
        {
            String visualName = String.Format("Selected{0}", pointName);
            Boolean result = VisualStateManager.GoToState(this, visualName, false);
        }
    }
}
