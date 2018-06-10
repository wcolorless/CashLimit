using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace CashLimit
{
    public class operations : INotifyPropertyChanged
    {
        private int type_p;
        private int value_p;
        private string description_p;
        private string date_p;


        public int Id { get; set; }

        public int type
        {
            get { return type_p; }
            set
            {
                type_p = value;
                OnPropertyChanged("type");
            }
        }
        public int value
        {
            get { return value_p; }
            set
            {
                value_p = value;
                OnPropertyChanged("value");
            }
        }
        public string description
        {
            get { return description_p; }
            set
            {
                description_p = value;
                OnPropertyChanged("description");
            }
        }
        public string date
        {
            get { return date_p; }
            set
            {
                date_p = value;
                OnPropertyChanged("date");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
