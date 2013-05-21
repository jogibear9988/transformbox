using System;

namespace DemoTransformBox.UI
{
    public class SelectedOperationEventArgs : EventArgs
    {
        public ManagementTransformOperation Operation { get; private set; }

        public SelectedOperationEventArgs(ManagementTransformOperation operation)
        {
            Operation = operation;
        }
    }
}
