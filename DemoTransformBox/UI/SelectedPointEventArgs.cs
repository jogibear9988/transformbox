using System;

namespace DemoTransformBox.UI
{
    public class SelectedPointEventArgs : EventArgs
    {
        public TransformPoint TransformPoint { get; private set; }

        public SelectedPointEventArgs(TransformPoint transformPoint)
        {
            TransformPoint = transformPoint;
        }
    }
}
