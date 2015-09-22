using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyContacts
{
	public static class EmployeeFactory
	{
		public static IList<Person> Characters { get; private set; }

		static EmployeeFactory()
		{
			Characters = new ObservableCollection<Person> {
				new Person { 
					Name = "Nat Friedman", 
					//HeadshotUrl = "Homer.gif", 
					Email = "nat@xamarin.com", 
					Title = "CEO",
					Gender = Gender.Male,
				},

				new Person {
					Name = "Stephanie Schatz",
					//HeadshotUrl = "Marge.gif",
					Email = "stephanie@xamarin.com",
					Title = "SVP of Sales",
					Gender = Gender.Female,
				},

				new Person { 
					Name = "Miguel de Icaza",
					//HeadshotUrl = "Bart.gif",
					Email = "miguel@xamarin.com",
					Title = "CTO",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "Andrew Way",
					//HeadshotUrl = "Lisa.gif",
					Email = "andrew.way@xamarin.com",
					Title = "Senior Customer Success Manager",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "James Clancey",
					//HeadshotUrl = "Maggie.gif",
					Email = "clancey@xamarin.com",
					Title = "App Developer",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "James White",
					//HeadshotUrl = "Krusty.gif",
					Email = "james.white@xamarin.com",
					Title = "Customer Success Engineer",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "Jo Ann Buckner",
					//HeadshotUrl = "Apu.gif",
					Email = "jo.ann.buckner@xamarin.com",
					Title = "Director of Marketing",
					Gender = Gender.Female,
				},

				new Person { 
					Name = "Xander A Monkey",
					//HeadshotUrl = "ComicBookGuy.gif",
					Email = "hello@xamarin.com",
					Title = "Mascot",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "Anuj Bhatia",
					//HeadshotUrl = "Milhouse.gif",
					Email = "anuj.bhatia@xamarin.com",
					Title = "Enterprise Customer Success Engineer",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "Chris Hardy",
					//HeadshotUrl = "MoeSzyslak.gif",
					Email = "chrisntr@xamarin.com",
					Title = "Director of Support",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "Joseph HIll",
					//HeadshotUrl = "MrBurns.gif",
					Email = "joseph@xamarin.com",
					Title = "COO",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "Frank Krueger",
					//HeadshotUrl = "SideshowBob.gif",
					Email = "fak@xamarin.com",
					Title = "Developer",
					Gender = Gender.Male,
				},

				new Person { 
					Name = "James Montemagno",
					//HeadshotUrl = "WaylonSmithers.gif",
					Email = "james.montemagno@xamarin.com",
					Title = "Developer Evangelist",
					Gender = Gender.Male,
				},
			};
		}
	}
}

