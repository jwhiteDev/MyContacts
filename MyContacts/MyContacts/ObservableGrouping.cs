using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace MyContacts
{
	/// <summary>
	/// This is used to provide change notification.
	/// </summary>
	public class ObservableGrouping<T> : ObservableCollection<T>
	{
		/// <summary>
		/// The grouping key. This can be the first character of the name of a person or something similar.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="MyContacts.ObservableGrouping`1"/> class.
		/// </summary>
		/// <param name="masterCollection">Master collection to watch. If elements get removed from this collection, the group will also update.</param>
		/// <param name="key">The grouping key. This can be the first character of the name of a person or something similar.</param>
		/// <param name="groups">The elements of the group.</param>
		public ObservableGrouping(IList<T> masterCollection, string key, IEnumerable<T> groups)
		{
			// Set the key and add all the included items.
			Key = key;

			// Add all elements to ourself.
			foreach (var item in groups)
			{
				this.Add(item);
			}

			// Watch the underlying collection this data came from.
			// If it changes, change this collection too.
			var incc = masterCollection as INotifyCollectionChanged;
			if (incc != null)
			{
				incc.CollectionChanged += HandleCollectionChanged;
			}
		}

		void HandleCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				// Remove any items from our group. It is possible that this particular group doesn't contain the item that was removed, 
				// but removing an item that does not exist does not cause an error.
				foreach (var item in e.OldItems.Cast<T>()) {
					this.Remove(item);
				}
			}
			// Student Exercise: implement other operations.
		}
	}
	
}
