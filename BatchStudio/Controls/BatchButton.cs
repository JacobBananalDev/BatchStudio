using System.Windows;
using System.Windows.Controls;

namespace BatchStudio.Controls
{
    public class BatchButton : Button
    {
        static BatchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BatchButton), new FrameworkPropertyMetadata(typeof(BatchButton)));
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(BatchButton), new PropertyMetadata(default(CornerRadius)));

    }
}
