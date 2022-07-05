using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AdonisUI;
using AdonisUI.Controls;

using Boyles.Tools.WindowsDebloat.ViewModels;

namespace Boyles.Tools.WindowsDebloat
{
    public partial class MainWindow : AdonisWindow
    {
        public static readonly DependencyProperty IsDarkProperty =
            DependencyProperty.Register("IsDark", typeof(bool), typeof(MainWindow), new PropertyMetadata(false, OnIsDarkChanged));

        public bool IsDark
        {
            get => (bool)GetValue(IsDarkProperty);
            set => SetValue(IsDarkProperty, value);
        }

        public MainWindow()
        {
            DataContext = new ApplicationViewModel();
            InitializeComponent();
        }

        #region Change Theme

        private static void OnIsDarkChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            ((MainWindow)dependencyObject).ChangeTheme((bool)args.OldValue);
        }

        private void ChangeTheme(bool oldValue)
        {
            ResourceLocator.SetColorScheme(Application.Current.Resources, oldValue ? ResourceLocator.LightColorScheme : ResourceLocator.DarkColorScheme);
        }

        #endregion
    }
}
