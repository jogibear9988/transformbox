using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TransformBox
{
    [TemplateVisualState(Name = "NaNOperation", GroupName = "OperationTransformBox")]
    [TemplateVisualState(Name = "RotateOperation", GroupName = "OperationTransformBox")]
    [TemplateVisualState(Name = "SkewOperation", GroupName = "OperationTransformBox")]
    [TemplateVisualState(Name = "ScaleOperation", GroupName = "OperationTransformBox")]
    [TemplateVisualState(Name = "TranslateOperation", GroupName = "OperationTransformBox")]
    [TemplateVisualState(Name = "CollapsedTransformBox", GroupName = "VisibilityTransformBox")]
    [TemplateVisualState(Name = "VisibleTransformBox", GroupName = "VisibilityTransformBox")]
    public class TransformBox : Control
    {
        static TransformBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TransformBox), new FrameworkPropertyMetadata(typeof(TransformBox)));
        }

        #region PointTransform

        #region PointA

        public Point PointA
        {
            get { return (Point)GetValue(PointAProperty); }
            private set { SetValue(PointAKey, value); }
        }
        internal static readonly DependencyPropertyKey PointAKey = DependencyProperty.RegisterReadOnly("PointA", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointAProperty = PointAKey.DependencyProperty;

        #endregion

        #region PointB

        public Point PointB
        {
            get { return (Point)GetValue(PointBProperty); }
            private set { SetValue(PointBKey, value); }
        }
        internal static readonly DependencyPropertyKey PointBKey = DependencyProperty.RegisterReadOnly("PointB", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointBProperty = PointBKey.DependencyProperty;

        #endregion

        #region PointC

        public Point PointC
        {
            get { return (Point)GetValue(PointCProperty); }
            private set { SetValue(PointCKey, value); }
        }
        internal static readonly DependencyPropertyKey PointCKey = DependencyProperty.RegisterReadOnly("PointC", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointCProperty = PointCKey.DependencyProperty;

        #endregion

        #region PointD

        public Point PointD
        {
            get { return (Point)GetValue(PointDProperty); }
            private set { SetValue(PointDKey, value); }
        }
        internal static readonly DependencyPropertyKey PointDKey = DependencyProperty.RegisterReadOnly("PointD", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointDProperty = PointDKey.DependencyProperty;

        #endregion

        #region PointE

        public Point PointE
        {
            get { return (Point)GetValue(PointEProperty); }
            private set { SetValue(PointEKey, value); }
        }
        internal static readonly DependencyPropertyKey PointEKey = DependencyProperty.RegisterReadOnly("PointE", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointEProperty = PointEKey.DependencyProperty;

        #endregion

        #region PointF

        public Point PointF
        {
            get { return (Point)GetValue(PointFProperty); }
            private set { SetValue(PointFKey, value); }
        }
        internal static readonly DependencyPropertyKey PointFKey = DependencyProperty.RegisterReadOnly("PointF", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointFProperty = PointFKey.DependencyProperty;

        #endregion

        #region PointG

        public Point PointG
        {
            get { return (Point)GetValue(PointGProperty); }
            private set { SetValue(PointGKey, value); }
        }
        internal static readonly DependencyPropertyKey PointGKey = DependencyProperty.RegisterReadOnly("PointG", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointGProperty = PointGKey.DependencyProperty;

        #endregion

        #region PointH

        public Point PointH
        {
            get { return (Point)GetValue(PointHProperty); }
            private set { SetValue(PointHKey, value); }
        }
        internal static readonly DependencyPropertyKey PointHKey = DependencyProperty.RegisterReadOnly("PointH", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointHProperty = PointHKey.DependencyProperty;

        #endregion

        #region PointCenter

        public Point PointCenter
        {
            get { return (Point)GetValue(PointCenterProperty); }
            private set { SetValue(PointCenterKey, value); }
        }
        internal static readonly DependencyPropertyKey PointCenterKey = DependencyProperty.RegisterReadOnly("PointCenter", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty PointCenterProperty = PointCenterKey.DependencyProperty;

        #endregion

        #region Center

        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            private set { SetValue(CenterKey, value); }
        }
        internal static readonly DependencyPropertyKey CenterKey = DependencyProperty.RegisterReadOnly("Center", typeof(Point), typeof(TransformBox), new PropertyMetadata(new Point()));
        public static readonly DependencyProperty CenterProperty = CenterKey.DependencyProperty;

        #endregion

        #endregion

        #region IsBusy

        public Boolean IsBusy
        {
            get { return (Boolean)GetValue(IsBusyProperty); }
            private set { SetValue(IsBusyKey, value); }
        }
        internal static readonly DependencyPropertyKey IsBusyKey = DependencyProperty.RegisterReadOnly("IsBusy", typeof(Boolean), typeof(TransformBox), new PropertyMetadata(false));
        public static readonly DependencyProperty IsBusyProperty = IsBusyKey.DependencyProperty;

        #endregion

        private Point[] originalPoint;

        private Panel Root { get; set; }
        private ContentPresenter Presenter { get; set; }
        private MatrixTransform Transform { get; set; }

        private PropertyTransformElement propertyTransformElement;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Root = GetTemplateChild("PART_Root") as Panel;

            Presenter = GetTemplateChild("PART_Presenter") as ContentPresenter;

            Transform = GetTemplateChild("PART_Transform") as MatrixTransform;

            FrameworkElement[] transformElements = new FrameworkElement[]
            {
                GetTemplateChild("PART_TranslateElement") as FrameworkElement,
                GetTemplateChild("PART_RotateA") as FrameworkElement,
                GetTemplateChild("PART_RotateB") as FrameworkElement,
                GetTemplateChild("PART_RotateC") as FrameworkElement,
                GetTemplateChild("PART_RotateD") as FrameworkElement,
                GetTemplateChild("PART_RotateE") as FrameworkElement,
                GetTemplateChild("PART_RotateF") as FrameworkElement,
                GetTemplateChild("PART_RotateG") as FrameworkElement,
                GetTemplateChild("PART_RotateH") as FrameworkElement,
                GetTemplateChild("PART_RotateH") as FrameworkElement,
                GetTemplateChild("PART_SkewAC") as FrameworkElement,
                GetTemplateChild("PART_SkewCE") as FrameworkElement,
                GetTemplateChild("PART_SkewEG") as FrameworkElement,
                GetTemplateChild("PART_SkewGA") as FrameworkElement,
                GetTemplateChild("PART_ScaleA") as FrameworkElement,
                GetTemplateChild("PART_ScaleB") as FrameworkElement,
                GetTemplateChild("PART_ScaleC") as FrameworkElement,
                GetTemplateChild("PART_ScaleD") as FrameworkElement,
                GetTemplateChild("PART_ScaleE") as FrameworkElement,
                GetTemplateChild("PART_ScaleF") as FrameworkElement,
                GetTemplateChild("PART_ScaleG") as FrameworkElement,
                GetTemplateChild("PART_ScaleH") as FrameworkElement,
                GetTemplateChild("PART_CentralPoint") as FrameworkElement
            };

            foreach (FrameworkElement element in transformElements)
            {
                if (element != null)
                {
                    element.MouseLeave += TransformMouseLeave;
                    element.MouseEnter += TransformMouseEnter;
                    element.MouseLeftButtonDown += TransformMouseLeftButtonDown;
                    element.MouseMove += TransformMouseMove;
                    element.MouseLeftButtonUp += TransformMouseLeftButtonUp;
                }
            }

            UpdateVisibilityTransformBox();
        }

        private void RenderTransformBox(Matrix matrix)
        {
            Point[] array = new Point[originalPoint.Length];

            for (Int32 i = 0; i < array.Length; i++)
            {
                array[i] = matrix.Transform(originalPoint[i]);
            }

            PointA = array[TP.A];
            PointB = array[TP.B];
            PointC = array[TP.C];
            PointD = array[TP.D];
            PointE = array[TP.E];
            PointF = array[TP.F];
            PointG = array[TP.G];
            PointH = array[TP.H];
            PointCenter = array[TP.Center];
            Center = array[TP.OriginalCenter];
        }

        #region UpdateVisualStateManager

        private void UpdateVisibilityTransformBox()
        {
            if (Presenter != null)
            {
                VisualStateManager.GoToState(this, Presenter.Content != null ? "VisibleTransformBox" : "CollapsedTransformBox", false);
            }
        }

        private void UpdateOperationTransformBox(TransformOperation operation)
        {
            String nameVisualStateGroup;

            switch (operation)
            {
                case TransformOperation.NaN:
                case TransformOperation.CentralPoint:
                    nameVisualStateGroup = "NaNOperation";
                    break;
                case TransformOperation.Translate:
                    nameVisualStateGroup = "TranslateOperation";
                    break;
                case TransformOperation.Rotate:
                    nameVisualStateGroup = "RotateOperation";
                    break;
                case TransformOperation.Skale:
                    nameVisualStateGroup = "ScaleOperation";
                    break;
                case TransformOperation.Skew:
                    nameVisualStateGroup = "SkewOperation";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("TransformMatrix.TransformBox.UpdateOperationTransformBox");
            }

            Boolean result = VisualStateManager.GoToState(this, nameVisualStateGroup, false);
        }

        #endregion

        #region Mouse

        private Boolean capture = false;
        private Point startMousePosition;
        private TransformName transformName = TransformName.NaN;
        private TransformOperation transformOperation = TransformOperation.NaN;

        private void TransformMouseEnter(object sender, MouseEventArgs e)
        {
            if (!capture)
            {
                FrameworkElement element = sender as FrameworkElement;
                TransformOperation transformOperation = GetTransformOperation(element);
                UpdateOperationTransformBox(transformOperation);
            }
        }

        private void TransformMouseLeave(object sender, MouseEventArgs e)
        {
            if (!capture)
            {
                UpdateOperationTransformBox(TransformOperation.NaN);
            }
        }

        private void TransformMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;

            if (element != null)
            {
                capture = e.MouseDevice.Capture(element, CaptureMode.Element);

                if (capture)
                {
                    String elementName = element.Name.Remove(0, 5);

                    if (!Enum.TryParse(elementName, out transformName))
                    {
                        transformName = TransformName.NaN;
                    }

                    transformOperation = GetTransformOperation(element);

                    startMousePosition = e.GetPosition(Root);

                    UpdateOperationTransformBox(transformOperation);
                }
            }
        }

        private void TransformMouseMove(object sender, MouseEventArgs e)
        {
            if (capture && transformOperation != TransformOperation.NaN && transformName != TransformName.NaN)
            {
                Point position = e.GetPosition(Root);

                Double offsetX = position.X - startMousePosition.X;
                Double offsetY = position.Y - startMousePosition.Y;

                switch (transformOperation)
                {
                    case TransformOperation.Translate:
                        Translate(offsetX, offsetY);
                        break;
                    case TransformOperation.Rotate:
                        Rotate(transformName, offsetX, offsetY);
                        break;
                    case TransformOperation.Skale:
                        Scale(transformName, startMousePosition, position);
                        break;
                    case TransformOperation.Skew:
                        Skew(transformName, startMousePosition, position);
                        break;
                    case TransformOperation.CentralPoint:
                        TranslateCentralPoint(offsetX, offsetY);
                        break;
                }

                startMousePosition = position;
            }
        }

        private void TransformMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            capture = false;
            transformName = TransformName.NaN;
            transformOperation = TransformOperation.NaN;
            e.MouseDevice.Capture(null);
            UpdateOperationTransformBox(transformOperation);
        }

        private TransformOperation GetTransformOperation(FrameworkElement element)
        {
            TransformOperation transformOperation = TransformOperation.NaN;

            if (element != null)
            {
                TransformName transformName;

                String elementName = element.Name.Remove(0, 5);

                if (!Enum.TryParse(elementName, out transformName))
                {
                    transformName = TransformName.NaN;
                }

                if (transformName == TransformName.NaN)
                {
                    transformOperation = TransformOperation.NaN;
                }
                else if (transformName == TransformName.CentralPoint)
                {
                    transformOperation = TransformOperation.CentralPoint;
                }
                else if (transformName == TransformName.TranslateElement)
                {
                    transformOperation = TransformOperation.Translate;
                }
                else if (transformName >= TransformName.RotateA && transformName <= TransformName.RotateH)
                {
                    transformOperation = TransformOperation.Rotate;
                }
                else if (transformName >= TransformName.ScaleA && transformName <= TransformName.ScaleH)
                {
                    transformOperation = TransformOperation.Skale;
                }
                else if (transformName >= TransformName.SkewAC && transformName <= TransformName.SkewGA)
                {
                    transformOperation = TransformOperation.Skew;
                }
            }

            return transformOperation;
        }

        #endregion

        #region Transform Element

        public void SetTransformElement(FrameworkElement element, bool useOriginalRect = false)
        {
            if (IsBusy == true)
            {
                throw new Exception("TransformBox IsBusy == true");
            }

            if (!(element.Width > 0) || !(element.Height > 0))
            {
                throw new ArgumentOutOfRangeException("!(Width > 0) || !(Height > 0)");
            }

            Panel parent = element.Parent as Panel;

            if (parent != null)
            {
                IsBusy = true;

                propertyTransformElement = new PropertyTransformElement
                {
                    Parent = parent,
                    ZPosition = parent.Children.IndexOf(element),
                    ZIndexElement = (Int32)element.GetValue(Panel.ZIndexProperty)
                };

                parent.Children.Remove(element);
                Presenter.Content = element;

                MatrixTransform originalTransform = element.RenderTransform as MatrixTransform;
                Rect originalRect = new Rect(0, 0, element.Width, element.Height);
                originalPoint = CalculationTransformPointPosition(originalTransform, originalRect, useOriginalRect);

                ApplyTransform(Matrix.Identity);

                UpdateVisibilityTransformBox();
            }
        }

        public void Commit()
        {
            FrameworkElement content = Presenter.Content as FrameworkElement;

            if (content != null)
            {
                MatrixTransform transform = content.RenderTransform as MatrixTransform;

                if (transform != null)
                {
                    transform.Matrix = transform.Matrix * Transform.Matrix;
                }

                Сleaning();
                UpdateVisibilityTransformBox();
            }
        }

        public void Rollback()
        {
            Сleaning();
            UpdateVisibilityTransformBox();
        }

        private void Сleaning()
        {
            FrameworkElement content = Presenter.Content as FrameworkElement;

            if (content != null && propertyTransformElement.Parent != null)
            {
                Presenter.Content = null;

                if (propertyTransformElement.ZPosition != -1)
                {
                    propertyTransformElement.Parent.Children.Insert(propertyTransformElement.ZPosition, content);
                }
                else
                {
                    propertyTransformElement.Parent.Children.Add(content);
                }

                content.SetValue(Panel.ZIndexProperty, propertyTransformElement.ZIndexElement);
            }

            propertyTransformElement = null;
            Transform.Matrix = Matrix.Identity;
            IsBusy = false;
        }

        private Point[] CalculationTransformPointPosition(MatrixTransform transform, Rect original, bool useOriginalRect)
        {
            if (useOriginalRect)
            {
                Rect rect = original;
                Point a = transform.Transform(new Point(rect.X, rect.Y));
                Point b = transform.Transform(new Point(rect.X + rect.Width / 2, rect.Y));
                Point c = transform.Transform(new Point(rect.X + rect.Width, rect.Y));
                Point d = transform.Transform(new Point(rect.X + rect.Width, rect.Y + rect.Height / 2));
                Point e = transform.Transform(new Point(rect.X + rect.Width, rect.Y + rect.Height));
                Point f = transform.Transform(new Point(rect.X + rect.Width / 2, rect.Y + rect.Height));
                Point g = transform.Transform(new Point(rect.X, rect.Y + rect.Height));
                Point h = transform.Transform(new Point(rect.X, rect.Y + rect.Height / 2));
                Point center = transform.Transform(new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2));
                return new Point[] { a, b, c, d, e, f, g, h, center, center };
            }
            else
            {
                Rect rect = transform.TransformBounds(original);
                Point a = new Point(rect.X, rect.Y);
                Point b = new Point(rect.X + rect.Width / 2, rect.Y);
                Point c = new Point(rect.X + rect.Width, rect.Y);
                Point d = new Point(rect.X + rect.Width, rect.Y + rect.Height / 2);
                Point e = new Point(rect.X + rect.Width, rect.Y + rect.Height);
                Point f = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height);
                Point g = new Point(rect.X, rect.Y + rect.Height);
                Point h = new Point(rect.X, rect.Y + rect.Height / 2);
                Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                return new Point[] { a, b, c, d, e, f, g, h, center, center };
            }
        }

        #endregion

        #region Transform Operation

        private void TranslateCentralPoint(Double offsetX, Double offsetY)
        {
            TranslateCentralPoint(new Point(PointCenter.X + offsetX, PointCenter.Y + offsetY));
        }

        private void Scale(TransformName transformName, Point oldPosition, Point newPosition)
        {
            Point offset = InvertTransformOffset(oldPosition, newPosition);

            Point center;
            Double scaleX = 1.0;
            Double scaleY = 1.0;

            Double width = originalPoint[TP.C].X - originalPoint[TP.A].X;
            Double height = originalPoint[TP.G].Y - originalPoint[TP.A].Y;

            switch (transformName)
            {
                case TransformName.ScaleA:
                    center = PointE;
                    scaleX = (width - offset.X) / width;
                    scaleY = (height - offset.Y) / height;
                    break;
                case TransformName.ScaleB:
                    center = PointF;
                    scaleY = (height - offset.Y) / height;
                    break;
                case TransformName.ScaleC:
                    center = PointG;
                    scaleX = (width + offset.X) / width;
                    scaleY = (height - offset.Y) / height;
                    break;
                case TransformName.ScaleD:
                    center = PointH;
                    scaleX = (width + offset.X) / width;
                    break;
                case TransformName.ScaleE:
                    center = PointA;
                    scaleX = (width + offset.X) / width;
                    scaleY = (height + offset.Y) / height;
                    break;
                case TransformName.ScaleF:
                    center = PointB;
                    scaleY = (height + offset.Y) / height;
                    break;
                case TransformName.ScaleG:
                    center = PointC;
                    scaleX = (width - offset.X) / width;
                    scaleY = (height + offset.Y) / height;
                    break;
                case TransformName.ScaleH:
                    center = PointD;
                    scaleX = (width - offset.X) / width;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("TransformMatrix.TransformBox.Scale");
            }

            Scale(scaleX, scaleY, center);

        }

        private void Rotate(TransformName transformName, Double x, Double y)
        {
            Point a;

            switch (transformName)
            {
                case TransformName.RotateA:
                    a = PointA;
                    break;
                case TransformName.RotateB:
                    a = PointB;
                    break;
                case TransformName.RotateC:
                    a = PointC;
                    break;
                case TransformName.RotateD:
                    a = PointD;
                    break;
                case TransformName.RotateE:
                    a = PointE;
                    break;
                case TransformName.RotateF:
                    a = PointF;
                    break;
                case TransformName.RotateG:
                    a = PointG;
                    break;
                case TransformName.RotateH:
                    a = PointH;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("TransformMatrix.TransformBox.Rotate");
            }

            Double angle = AngularСoefficient(PointCenter, a, x, y);
            Rotate(angle, PointCenter);
        }

        private void Skew(TransformName transformName, Point oldPosition, Point newPosition)
        {
            Point offset = InvertTransformOffset(oldPosition, newPosition);

            Boolean isHorisontal;

            Point a, b, center;

            switch (transformName)
            {
                case TransformName.SkewAC:
                    a = originalPoint[TP.A];
                    b = originalPoint[TP.G];
                    center = PointG;
                    isHorisontal = true;
                    break;
                case TransformName.SkewCE:

                    a = originalPoint[TP.A];
                    b = originalPoint[TP.C];
                    center = PointA;
                    isHorisontal = false;
                    break;
                case TransformName.SkewEG:
                    a = originalPoint[TP.G];
                    b = originalPoint[TP.A];
                    center = PointC;
                    isHorisontal = true;
                    break;
                case TransformName.SkewGA:
                    a = originalPoint[TP.E];
                    b = originalPoint[TP.G];
                    center = PointE;
                    isHorisontal = false;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("TransformMatrix.TransformBox.Skew");
            }

            Double angle = AngularСoefficient(a, b, offset.X, offset.Y);

            Double skewX = isHorisontal ? angle : 0;
            Double skewY = isHorisontal ? 0 : angle;

            Skew(skewX, skewY, center);
        }

        private Double AngularСoefficient(Point a, Point b, Double x, Double y)
        {
            b.X = b.X != a.X ? b.X : b.X + 0.00000001;
            x = (b.X + x) != a.X ? x : x + 0.00000001;

            Double koef1 = (b.Y - a.Y) / (b.X - a.X);
            Double koef2 = (b.Y + y - a.Y) / (b.X + x - a.X);

            Double k = koef1 * koef2;

            k = (k != -1) ? k : k + 0.00000001;

            Double koef = (koef2 - koef1) / (1 + k);

            return Math.Atan(koef) * 180 / Math.PI;
        }

        private Point InvertPosition(Point position)
        {
            Matrix matrix = Transform.Matrix;
            matrix.Invert();
            return matrix.Transform(position);
        }

        private Point InvertTransformOffset(Point oldPosition, Point newPosition)
        {
            Point transformOldPosition = InvertPosition(oldPosition);
            Point transformNewPosition = InvertPosition(newPosition);

            return new Point(transformNewPosition.X - transformOldPosition.X, transformNewPosition.Y - transformOldPosition.Y);
        }

        private Boolean ApplyTransform(Matrix matrix)
        {
            Boolean isNotSingularMatrix = false;

            if (Math.Round(matrix.Determinant, 7) != 0)
            {
                RenderTransformBox(matrix);
                Transform.Matrix = matrix;
                isNotSingularMatrix = true;
            }
            return isNotSingularMatrix;
        }

        #endregion

        #region Public Transform Operation

        public void TranslateCentralPoint(Point position)
        {
            Point invertPosition = InvertPosition(position);

            originalPoint[TP.Center].X = invertPosition.X;
            originalPoint[TP.Center].Y = invertPosition.Y;

            RenderTransformBox(Transform.Matrix);
        }

        public Boolean Translate(Double offsetX, Double offsetY)
        {
            Boolean isTransform = false;
            if (Transform != null)
            {
                Matrix matrix = Transform.Matrix;
                matrix.Translate(offsetX, offsetY);
                isTransform = ApplyTransform(matrix);
            }
            return isTransform;
        }

        public Boolean Rotate(Double angle, Point center)
        {
            Boolean isTransform = false;

            if (Transform != null)
            {
                Matrix matrix = Transform.Matrix;
                matrix.RotateAt(angle, center.X, center.Y);
                isTransform = ApplyTransform(matrix);
            }

            return isTransform;
        }

        public Boolean Scale(Double scaleX, Double scaleY, Point center)
        {
            Boolean isTransform = false;
            if (Transform != null)
            {
                Point invertCenter = InvertPosition(center);
                Matrix matrix = Transform.Matrix;
                matrix.ScaleAtPrepend(scaleX, scaleY, invertCenter.X, invertCenter.Y);
                isTransform = ApplyTransform(matrix);
            }
            return isTransform;
        }

        public Boolean Skew(Double skewX, Double skewY, Point center)
        {
            Boolean isTransform = false;

            if (Transform != null)
            {
                Point invertCenter = InvertPosition(center);

                SkewTransform skewTransform = new SkewTransform(skewX, skewY, invertCenter.X, invertCenter.Y);

                Matrix matrix = Transform.Matrix;
                matrix.Prepend(skewTransform.Value);

                isTransform = ApplyTransform(matrix);
            }

            return isTransform;
        }

        #endregion
    }
}
