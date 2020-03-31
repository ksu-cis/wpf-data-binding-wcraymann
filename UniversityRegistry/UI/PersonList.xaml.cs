/*
 * Author: Nathan Bean
 * Edited By: William Rayman.
 * Class: PersonList.
 * Purpose: To display all current people in the University and to 
 *          allo the user to add more.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using UniversityRegistry.Data;

namespace UniversityRegistry.UI
{
    /// <summary>
    /// Interaction logic for RegistryList.xaml
    /// </summary>
    public partial class PersonList : UserControl
    {
        public PersonList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Serves as a proxy event handler for selection changes
        /// in ListView of people.
        /// </summary>
        public event SelectionChangedEventHandler ListChanged;

        /// <summary>
        /// Invokes the ListChanged event handler whenever a change is made to 
        /// the selecion of the ListView of people.
        /// </summary>
        /// <param name="sender">The calling ListView of people.</param>
        /// <param name="e">Information about the calling ListView.</param>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Addes a new person to the ListView of people in the 
        /// university.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnAddNewPerson(object sender, RoutedEventArgs e)
        {
            (DataContext as ObservableCollection<Person>).Add(new Person()
            {
                FirstName = "New",
                LastName = "Person",
                DateOfBirth = new DateTime(2000, 01, 01),
                Role = Role.UndergraduateStudent,
                Active = true
            });

            PeopleDisplay.SelectedItem = PeopleDisplay.Items[PeopleDisplay.Items.Count - 1];
        }
    }
}
