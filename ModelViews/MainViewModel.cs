using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Kalum2020v1.Views;

namespace Kalum2020v1.ModelViews
{
    public class MainViewModel : INotifyPropertyChanged, ICommand
    {
        public MainViewModel _Instancia;
        public MainViewModel Instancia {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
                NotificarCambio("Instancia");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("AlumnosView"))
            {
               AlumnoView view =  new AlumnoView();
               view.ShowDialog();
            }
        }

        public MainViewModel()
        {
            this.Instancia = this;            
        }

        public void NotificarCambio(string propiedad)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}