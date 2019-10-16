using System.ComponentModel;

namespace Pocztowy.Models
{   
    public abstract class BaseEntity : BaseEntity<int>
    {

    }

    public abstract class BaseEntity<TKey> : INotifyPropertyChanged
    {
        public TKey Id { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
