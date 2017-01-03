using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using Xamarin.Forms;


namespace InstallDemo
{
    [Table("Groups")]
    public class GroupData : INotifyPropertyChanged
    {
       
        private int _id;
        [PrimaryKey, AutoIncrement]

        public int ID {
            get { return _id; }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(ID));
            }         
        }
       
        
        private string _GroupName;
        [PrimaryKey,MaxLength(25), NotNull]
        public string groupName
        {
            get { return _GroupName; }
            set
            {
                this._GroupName = value;
                OnPropertyChanged(nameof(groupName));
            }
        }
            //implement list of contacts


            public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        }
        

       

    }

