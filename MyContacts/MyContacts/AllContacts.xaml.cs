using System;
using Xamarin.Forms;
using System.Linq;

namespace MyContacts
{    
	public partial class AllContacts : ContentPage
	{    
	    public AllContacts ()
	    {
//            BindingContext = EmployeeFactory.Characters
//                .OrderBy(c => c.Name)
//                .GroupBy(c => c.Name[0].ToString(), c => c);

            // Create the grouping.
            // This will be a List<Linq.IGrouping<string, Person>>, where "string" is the grouping key and "Person" is a list (an IGrouping) of objects.
            var groups = EmployeeFactory.Characters
                .OrderBy(c => c.Name)
                .GroupBy(c => c.Name[0].ToString(), c => c).ToList();

            // Use new ObservableGrouping class (source included). The result will be a List<ObservableGrouping<Person>>.
            // Each ObservableGrouping instance has a reference to the full orginal list of elements (EmployeeFactory.Characters) and subscribes
            // to its "CollectionChanged" event. That means: if anything changes in the original collection, each group will also be updated.
            // Note: if we want to add elements to the groupedElements, it will have to be an ObservableCollection<T>.
            var groupedElements = groups.Select(g => new ObservableGrouping<Person>(EmployeeFactory.Characters, g.Key, g)).ToList();

            // Assign the observable grops to the binding context so they can be used with bindings.
            BindingContext = groupedElements;
            
	        InitializeComponent ();
			InitializeToolbar();
	    }

		async void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (!isEditing) {
				Person tappedPerson = (Person)e.Item;
				await this.Navigation.PushAsync(new ContactDetails(tappedPerson));
			}
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (isEditing) {
				Person person = (Person)e.SelectedItem;
				if (person != null) {
					if (await this.DisplayAlert("Confirm", "Are you sure you want to delete " + person.Name, "Yes", "No") == true) {
						EmployeeFactory.Characters.Remove(person);
					}
				}
				OnEdit(null, EventArgs.Empty);
			}

            ((ListView)sender).SelectedItem = null;
		}

		bool isEditing;
		ToolbarItem editButton;

		void InitializeToolbar()
		{
			editButton = new ToolbarItem() { Text = "Edit" };
			editButton.Clicked += OnEdit;
            ToolbarItems.Add(editButton);
		}

		void OnEdit(object sender, EventArgs e)
		{
            isEditing = !isEditing;
            editButton.Text = isEditing ? "End Edit" : "Edit";
		}
	}
}

