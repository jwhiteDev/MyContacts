using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PCLCrypto;

namespace MyContacts
{
	public class Person : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		public string HeadshotUrl {
            get
            {
                var hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Md5);
                byte[] hash = hasher.HashData(Encoding.UTF8.GetBytes(email.Trim()));

                var hashString = string.Join(string.Empty, hash.Select(x => x.ToString("x2")));
                var uri = string.Format("http://www.gravatar.com/avatar/{0}.jpg?s={1}&d=mm", hashString, 80);
                return uri;

            }
        }

		string name;
		public string Name { 
			get { return name; }
			set { SetProperty(ref name, value);	}
		}

		string email;
		public string Email {
			get { return email; }
			set { SetProperty(ref email, value); }
		}

		string title;
		public string Title {
			get { return title; }
			set { SetProperty(ref title, value);	}
		}

		Gender gender;
		public Gender Gender {
			get { return gender; }
			set { SetProperty(ref gender, value); }
		}

		/// <summary>
		/// Method to compare and replace a field's value and raise a 
		/// PropertyChanged notification if it was altered.
		/// </summary>
		/// <returns><c>true</c>, if field was set, <c>false</c> otherwise.</returns>
		/// <param name="field">Field.</param>
		/// <param name="value">Value.</param>
		/// <param name="propertyName">Property name.</param>
		/// <typeparam name="T">Field type.</typeparam>
		bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = "") 
		{
			if (!object.Equals(field, value)) {
				field = value;
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("Name={0}, Email={1}, Gender={2}", 
	            this.Name, this.Email, this.Title, this.Gender);
		}
	}
    
}
