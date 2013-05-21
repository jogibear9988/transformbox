using DemoTransformBox.UI;
using System;
using System.Windows;
using System.Windows.Input;

namespace DemoTransformBox
{
    public partial class MainWindow : Window
    {
        private const Double ADDTRANSLATE = 1;
        private const Double ADDSCALE = 1.1;
        private const Double ADDROTATE = 1;
        private const Double ADDSKEW = 1;

        private Point centralPoint;
        private TransformPoint transformPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImageMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (!transformBox.IsBusy)
                {
                    FrameworkElement element = sender as FrameworkElement;
                    {
                        EnabledManagementTransform(true);
                        transformBox.SetTransformElement(element);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void ManagementTransformSelectedOperation(object sender, SelectedOperationEventArgs e)
        {
            centralPoint = transformBox.PointCenter;

            switch (e.Operation)
            {
                case ManagementTransformOperation.NaN:
                    break;
                case ManagementTransformOperation.TranslateLeft:
                    transformBox.Translate(-ADDTRANSLATE, 0);
                    break;
                case ManagementTransformOperation.TranslateTop:
                    transformBox.Translate(0, -ADDTRANSLATE);
                    break;
                case ManagementTransformOperation.TranslateBootom:
                    transformBox.Translate(0, ADDTRANSLATE);
                    break;
                case ManagementTransformOperation.TranslateRight:
                    transformBox.Translate(ADDTRANSLATE, 0);
                    break;
                case ManagementTransformOperation.EnlargeHeight:
                    transformBox.Scale(1, ADDSCALE, centralPoint);
                    break;
                case ManagementTransformOperation.EnlargeWidth:
                    transformBox.Scale(ADDSCALE, 1, centralPoint);
                    break;
                case ManagementTransformOperation.ReduceHeight:
                    transformBox.Scale(1, 1.0 / ADDSCALE, centralPoint);
                    break;
                case ManagementTransformOperation.ReduceWidth:
                    transformBox.Scale(1.0 / ADDSCALE, 1, centralPoint);
                    break;
                case ManagementTransformOperation.RotateCCW:
                    transformBox.Rotate(-ADDROTATE, centralPoint);
                    break;
                case ManagementTransformOperation.RotateCW:
                    transformBox.Rotate(ADDROTATE, centralPoint);
                    break;
                case ManagementTransformOperation.Skew1:
                    transformBox.Skew(0, ADDSKEW, centralPoint);
                    break;
                case ManagementTransformOperation.Skew2:
                    transformBox.Skew(0, -ADDSKEW, centralPoint);
                    break;
                case ManagementTransformOperation.Skew3:
                    transformBox.Skew(-ADDSKEW, 0, centralPoint);
                    break;
                case ManagementTransformOperation.Skew4:
                    transformBox.Skew(ADDSKEW, 0, centralPoint);
                    break;
                case ManagementTransformOperation.Ok:
                    transformBox.Commit();
                    EnabledManagementTransform(false);
                    break;
                case ManagementTransformOperation.Cansel:
                    transformBox.Rollback();
                    EnabledManagementTransform(false);
                    break;
                default:
                    break;
            }
        }

        private void ManagementTransformSelectedPoint(object sender, SelectedPointEventArgs e)
        {
            transformPoint = e.TransformPoint;
            centralPoint = GetCentralPoint(e.TransformPoint);
            transformBox.TranslateCentralPoint(centralPoint);
        }

        private void EnabledManagementTransform(Boolean enabled)
        {
            if (enabled)
            {
                managementTransform.IsEnabled = true;
            }
            else
            {
                managementTransform.IsEnabled = false;
            }
        }

        private Point GetCentralPoint(TransformPoint point)
        {
            Point p = new Point();

            switch (point)
            {
                case TransformPoint.A:
                    p = transformBox.PointA;
                    break;
                case TransformPoint.B:
                    p = transformBox.PointB;
                    break;
                case TransformPoint.C:
                    p = transformBox.PointC;
                    break;
                case TransformPoint.D:
                    p = transformBox.PointD;
                    break;
                case TransformPoint.E:
                    p = transformBox.PointE;
                    break;
                case TransformPoint.F:
                    p = transformBox.PointF;
                    break;
                case TransformPoint.G:
                    p = transformBox.PointG;
                    break;
                case TransformPoint.H:
                    p = transformBox.PointH;
                    break;
                case TransformPoint.NaN:
                case TransformPoint.CentralPoint:
                    p = transformBox.Center;
                    break;
                default:
                    break;
            }

            return p;
        }
    }
}
