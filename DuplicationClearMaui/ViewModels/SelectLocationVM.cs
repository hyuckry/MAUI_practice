using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using DuplicationClearMaui.Views;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DuplicationClearMaui.ViewModels
{

    public partial class SelectLocationVM : INotifyPropertyChanged, IQueryAttributable
    { 

        readonly IList<string> source;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> SelectFolders { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            throw new NotImplementedException();
        }

        public SelectLocationVM()
        {
            source = new List<string>();

            CreateFolderList();
        }

        private void CreateFolderList()
        {
            source.Add("H:\\11.강좌\\00.시청중");
            source.Add("H:\\11.강좌\\01.완료");
            source.Add("H:\\11.강좌\\08.Database");
            source.Add("H:\\11.강좌\\14.English");
            source.Add("H:\\11.강좌\\99.기타");
            source.Add("H:\\11.강좌\\dwhelper");
            source.Add("H:\\11.강좌\\Linux");
            source.Add("H:\\11.강좌\\MAUI");
            source.Add("H:\\11.강좌\\ portfolio");
            source.Add("H:\\11.강좌\\강좌");
            source.Add("H:\\11.강좌\\강좌.Adobe");
            source.Add("H:\\11.강좌\\강좌.Azure.MS");
            source.Add("H:\\11.강좌\\강좌.Blazor");
            source.Add("H:\\11.강좌\\강좌.Clone");
            source.Add("H:\\11.강좌\\강좌.css");
            source.Add("H:\\11.강좌\\강좌.Drawing");
            source.Add("H:\\11.강좌\\강좌.Electron");
            source.Add("H:\\11.강좌\\강좌.EntityFramework");
            source.Add("H:\\11.강좌\\강좌.Excel");
            source.Add("H:\\11.강좌\\강좌.iOS");
            source.Add("H:\\11.강좌\\강좌.ipad");
            source.Add("H:\\11.강좌\\강좌.javascript");
            source.Add("H:\\11.강좌\\강좌.Mosh");
            source.Add("H:\\11.강좌\\강좌.Next.js");
            source.Add("H:\\11.강좌\\강좌.OpenGL.OpenCV");
            source.Add("H:\\11.강좌\\강좌.PowerShell");
            source.Add("H:\\11.강좌\\강좌.Python");
            source.Add("H:\\11.강좌\\강좌.react.js");
            source.Add("H:\\11.강좌\\강좌.typescript");
            source.Add("H:\\11.강좌\\강좌.Unity");
            source.Add("H:\\11.강좌\\강좌.Unreal");
            source.Add("H:\\11.강좌\\강좌.WPF");
            source.Add("H:\\11.강좌\\강좌.Xamarin");
            source.Add("H:\\11.강좌\\강좌.기타");
            source.Add("H:\\11.강좌\\관심강좌");

            SelectFolders = new ObservableCollection<string>(source);
        }

        #region Command
        public ICommand DeleteCommand => new Command<string>(DeleteFolder);
        public ICommand SearchCommand => new Command(SearchSubFolder);

        [RelayCommand]
        private async void SearchSubFolder(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(SearchResultPage)}",true);
        }

        private void DeleteFolder(string obj)
        {
            
        }
        #endregion
    }
}
