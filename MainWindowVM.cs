using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Individual_4314.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Individual_4314
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedusr = null;



        public void ExitMain()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void message()
        {

            MessageBox.Show($"{selectedusr.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedusr != null)
            {
                string name = selectedusr.FirstName;
                users.Remove(selectedusr);
                MessageBox.Show($"{name} is deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("You must select a student !", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedusr != null)
            {
                var vm = new AddUserVM(selectedusr);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedusr);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("You must select a student before editing !", "Warning!");
            }
        }

        public MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/10.png", UriKind.Relative));
            users.Add(new User(12, "Nipun", "Kumara", "12/10/2000", image1));

            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(12, "Sachin", "Gamage", "11/01/2000", image2));

            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(12, "Kamal", "Bandara", "21/04/2000", image3));

            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(12, "Lakshan", "Rathnayake", "14/07/2000", image4));

        }
    }
}
