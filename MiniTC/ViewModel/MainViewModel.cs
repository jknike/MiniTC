using System.Windows.Input;
using System.IO;

namespace MiniTC.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {

        private PanelTCViewModel _od;
        private PanelTCViewModel _do;
        public RelayCommand Kopiowanie { get; set; }
        private string sciezkaPliku, sciezkaFolderu, fileName;
        public MainViewModel()
        {
            Od = new PanelTCViewModel();
            Do = new PanelTCViewModel();
            Kopiowanie = new RelayCommand(arg => Kopiuj(), arg => Sprawdzenie());
        }
        public PanelTCViewModel Od
        {
            get { return _od; }
            set { _od = value; onPropertyChanged(nameof(Od)); }
        }
        public PanelTCViewModel Do
        {
            get { return _do; }
            set { _do = value; onPropertyChanged(nameof(Do)); }
        }
        private bool Sprawdzenie()
        {
            if (Od.Sciezka == Do.Sciezka)
                return false;

            if (Od.WybranyDir != null && !Od.WybranyDir.Contains("[D]") && Od.WybranyDir != ".." && Do.Sciezka != null)
                return true;

            if (Do.WybranyDir != null && !Do.WybranyDir.Contains("[D]") && Do.WybranyDir != ".." && Od.Sciezka != null)
                return true;

            return false;
        }
        private void Kopiuj()
        {
            if (Od.WybranyDir != null)
            {
                sciezkaPliku = Od.Sciezka + "\\" + Od.WybranyDir.Trim();
                sciezkaFolderu = Do.Sciezka;

                fileName = Path.GetFileName(sciezkaPliku);
                File.Copy(sciezkaPliku, sciezkaFolderu + "\\" + fileName);
                Od.Sciezka = Od.Sciezka;
                Do.Sciezka = Do.Sciezka;
            }
            else if (Do.WybranyDir != null)                                       
            {
                sciezkaPliku = Do.Sciezka + "\\" + Do.WybranyDir.Trim();
                sciezkaFolderu = Od.Sciezka;

                fileName = Path.GetFileName(sciezkaPliku);
                File.Copy(sciezkaPliku, sciezkaFolderu + "\\" + fileName);
                Od.Sciezka = Od.Sciezka;
                Do.Sciezka = Do.Sciezka;
            }
        }
    }
}