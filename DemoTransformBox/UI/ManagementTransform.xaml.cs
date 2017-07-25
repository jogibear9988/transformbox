using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;


namespace DemoTransformBox.UI
{
    public partial class ManagementTransform : UserControl, IDisposable
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

        #region SelectedOperation

        public event EventHandler<SelectedOperationEventArgs> SelectedOperation;

        private void OnSelectedOperation(ManagementTransformOperation operation)
        {
            if (SelectedOperation != null)
            {
                SelectedOperation(this, new SelectedOperationEventArgs(operation));
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            StopTimer();
        }

        #endregion

        private Timer timer;

        public ManagementTransform()
        {
            InitializeComponent();
        }

        private void PointSelectorSelectedPoint(object sender, SelectedPointEventArgs e)
        {
            OnSelectedPoint(e.TransformPoint);
        }

        private void TransformOperationPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            ManagementTransformOperation operation = (ManagementTransformOperation)Enum.Parse(typeof(ManagementTransformOperation), element.Name, true);

            if (operation == ManagementTransformOperation.Ok || operation == ManagementTransformOperation.Cansel)
            {
                OnSelectedOperation(operation);
            }
            else
            {
                timer = new Timer(TimerTick, operation, 0, 100);
            }
        }

        private void TransformOperationPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StopTimer();
        }

        private void TimerTick(Object obj)
        {
            ManagementTransformOperation operation = (ManagementTransformOperation)obj;
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action<ManagementTransformOperation>)OnSelectedOperation, operation);
        }

        private void StopTimer()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }

        private void TransformMouseMouseLeave(object sender, MouseEventArgs e)
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }
    }
}
