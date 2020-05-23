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

namespace MiniTC.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }
        public List<string> Dyski
        {
            get { return (List<string>)GetValue(DyskiProperty); }
            set { SetValue(DyskiProperty, value); }
        }
        private static readonly DependencyProperty DyskiProperty =
            DependencyProperty.Register("Dyski", typeof(List<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public List<string> ZawartoscFolderu
        {
            get { return (List<string>)GetValue(ZawartoscFolderuProperty); }
            set { SetValue(ZawartoscFolderuProperty, value); }
        }
        private static readonly DependencyProperty ZawartoscFolderuProperty =
            DependencyProperty.Register("ZawartoscFolderu", typeof(List<string>), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public string WybranyDysk
        {
            get { return (string)GetValue(WybranyDyskProperty); }
            set { SetValue(WybranyDyskProperty, value); }
        }
        private static readonly DependencyProperty WybranyDyskProperty =
            DependencyProperty.Register("WybranyDysk", typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public string WybranyDir
        {
            get { return (string)GetValue(WybranyDirProperty); }
            set { SetValue(WybranyDirProperty, value); }
        }
        private static readonly DependencyProperty WybranyDirProperty =
            DependencyProperty.Register("WybranyDir", typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));
        public string Sciezka
        {
            get { return (string)GetValue(SciezkaProperty); }
            set { SetValue(SciezkaProperty, value); }
        }
        private static readonly DependencyProperty SciezkaProperty =
            DependencyProperty.Register("Sciezka", typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public ICommand OpenFolder
        {
            get { return (ICommand)GetValue(OpenFolderProperty); }
            set { SetValue(OpenFolderProperty, value); }
        }
        private static readonly DependencyProperty OpenFolderProperty =
            DependencyProperty.Register("OpenFolder", typeof(ICommand), typeof(PanelTC), new FrameworkPropertyMetadata(null));
    }
}
