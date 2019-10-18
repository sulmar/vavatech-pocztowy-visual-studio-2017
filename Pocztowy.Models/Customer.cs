using System;
using System.Collections;

// usunięcie nieużywanych usingów Ctrl+R,G

namespace Pocztowy.Models
{

    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO HomeAddress { get; set; }
        public AddressDTO WorkAddress { get; set; }
    }

    public class AddressDTO
    {
        public AddressDTO(string city, string street)
        {
            City = city ?? throw new ArgumentNullException(nameof(city));
            Street = street ?? throw new ArgumentNullException(nameof(street));
        }

        public string City { get;  }
        public string Street { get; }

    }


    // Ctrl+[, S
    public class Customer : BaseEntity
    {
       


        // Ctrl+E,V Duplikacja kodu
        

        // Ctrl+L usunięcie linii

        private string _lastName;

        public Customer(string firstName, string lastName, byte age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

       

        // Ctrl+M+M (zwinięcie/rozwinięcie aktywnego regionu)
        // Ctrl+M+L (zwinięcie/rozwinięcie wszystkich regionów)


        // formatowanie kodu w całym pliku Ctrl+K,D

        // formatowanie kodu w zaznaczonym bloku Ctrl+K,F

        public string FirstName { get; set; }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }

            }
        }


        private decimal _Salary;
        public decimal Salary
        {
            get { return _Salary; }
            set
            {
                if (value != _Salary)
                {
                    _Salary = value;
                    OnPropertyChanged(nameof(Salary));
                }
            }
        }

        public byte Age { get; }

        public Address HomeAddress { get; set; }
        public Address WorkAddress { get; set; }
        public Address PostAddress { get; set; }

        // pisanie równoczesne
        // Shift+Alt+kursor
        // Alt+myszka

        public bool IsRemoved { get; set; }
    }
}
