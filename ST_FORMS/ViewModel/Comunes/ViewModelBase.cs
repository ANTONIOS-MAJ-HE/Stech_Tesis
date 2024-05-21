using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ST_FORMS.ViewModel.Comunes
{
    // Definición de la clase ViewModelBase
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Evento PropertyChanged que notifica a la vista cuando una propiedad cambia
        public event PropertyChangedEventHandler PropertyChanged;

        // Método para notificar cambios en una propiedad
        public void OnPropertyChanged(string propertyName)
        {
            // Verifica si hay manejadores de eventos suscritos al evento PropertyChanged
            // y luego invoca el evento, pasando este objeto de ViewModelBase como el remitente
            // y un objeto PropertyChangedEventArgs que contiene el nombre de la propiedad que cambió
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
