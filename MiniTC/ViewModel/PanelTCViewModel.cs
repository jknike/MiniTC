using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    internal class PanelTCViewModel : ViewModelBase
    {   
        private List<string> _dyski;
        private List<string> _zawartoscFolderu;
        private string _wybranyDysk;            
        private string _wybranyDir;
        private string _sciezka;
        private ICommand _zmianaDir = null;

        public List<string> Dyski
        {
            get { return _dyski; }
            set{  _dyski = value; onPropertyChanged(nameof(_dyski));}
        }
        public string WybranyDysk
        {
            get { return _wybranyDysk; }
            set { _wybranyDysk = value; onPropertyChanged(nameof(WybranyDysk)); ZmienSciezke();}
        }
        public string WybranyDir
        {
            get { return _wybranyDir; }
            set{_wybranyDir = value; onPropertyChanged(nameof(WybranyDir));}
        }
        public List<string> ZawartoscFolderu
        {
            get { return _zawartoscFolderu; }
            set{ _zawartoscFolderu = value; onPropertyChanged(nameof(ZawartoscFolderu));}
        }
        public string Sciezka
        {
            get { return _sciezka; }
            set { _sciezka = value; onPropertyChanged(nameof(Sciezka));  ZmienWypisaneFoldery();}
        }

        public PanelTCViewModel()
        {
            Dyski = new List<string>();
            WypiszDyski();
            WybranyDysk = Dyski[0];
        }

        private void WypiszDyski()
        {
            Dyski.Clear();
            Directory.GetLogicalDrives().ToList().ForEach(x => Dyski.Add(x));
        }
        public ICommand ZmienDir
        {
            get
            {
                if (_zmianaDir == null)
                {
                    _zmianaDir = new RelayCommand(arg => {
                        if (_wybranyDir == "..") Sciezka = Directory.GetParent(Sciezka).FullName; else { if (Sciezka.EndsWith("\\")) Sciezka += _wybranyDir.Replace("[D] ", ""); else Sciezka += "\\" + _wybranyDir.Replace("[D] ", ""); }}, arg => Sprawdzenie());
                }
                return _zmianaDir;
            }
        }

        private bool Sprawdzenie()
        {
            if (_wybranyDir == "..")
                return true;
            if (_wybranyDir != null && _wybranyDir.Contains("[D]"))
                return true;
            return false;
        }

        private void ZmienSciezke()
        {
            Sciezka = _wybranyDysk;
        }

        private void ZmienWypisaneFoldery()
        {
            List<string> pliki = new List<string>();
            List<string> katalogi = new List<string>();
            List<string> temp = new List<string>();

            Directory.GetFiles(Sciezka).ToList().ForEach(x => pliki.Add(x));
            Directory.GetDirectories(Sciezka).ToList().ForEach(x => katalogi.Add(x));
            DirectoryInfo plikNadrzedny = Directory.GetParent(Sciezka);

            if (plikNadrzedny != null) 
                temp.Add("..");
            foreach (string katalog in katalogi)
                    temp.Add("[D] " + Path.GetFileName(katalog));
            foreach (string plik in pliki)
                    temp.Add("     " + Path.GetFileName(plik));
            ZawartoscFolderu = temp;
        }
    }
}