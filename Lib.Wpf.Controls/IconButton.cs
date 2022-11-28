using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lib.Wpf.Controls
{
    public class IconButton : Button
    {
        static IconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(IconButton),
                new FrameworkPropertyMetadata(typeof(IconButton))
                );
        }

        #region IconPathData

        public Geometry IconPathData
        {
            get { return (Geometry)GetValue(IconPathDataProperty); }
            set { SetValue(IconPathDataProperty, value); }
        }
        public static readonly DependencyProperty IconPathDataProperty =
            DependencyProperty.Register(
                nameof(IconPathData),
                typeof(Geometry),
                typeof(IconButton),
                new FrameworkPropertyMetadata(null));

        #endregion

        #region BasicColor

        public Brush BasicColor
        {
            get { return (Brush)GetValue(BasicColorProperty); }
            set { SetValue(BasicColorProperty, value); }
        }
        public static readonly DependencyProperty BasicColorProperty =
            DependencyProperty.Register(
                nameof(BasicColor),
                typeof(Brush),
                typeof(IconButton),
                new PropertyMetadata((Brush?)null), null);

        public Brush OnHoverColor
        {
            get { return (Brush)GetValue(OnHoverColorProperty); }
            set { SetValue(OnHoverColorProperty, value); }
        }
        public static readonly DependencyProperty OnHoverColorProperty =
            DependencyProperty.Register(
                nameof(OnHoverColor),
                typeof(Brush),
                typeof(IconButton),
                new PropertyMetadata((Brush?)null), null);

        #endregion
    }
}
