using CommonLibrary.Messages.Users;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommonLibrary.Containers
{
    [Serializable]
    public class UserItemWrap : INotifyPropertyChanged
    {
        private ObservableCollection<ImageContainer> images = new ObservableCollection<ImageContainer>();
        public PublicUserInfo User { get; set; }

        public ObservableCollection<ImageContainer> Images 
        { 
            get => images;
            set
            {
                images = value;
                OnPropertyChanged();
            }
        }

        public UserItemWrap()
        {

        }

        public UserItemWrap(PublicUserInfo user) => User = user;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
