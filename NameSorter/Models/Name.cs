using System;

namespace NameSorter.Models
{
    public class Name : IEquatable<Name>, IComparable<Name>
    {
        // Note: using 'newer' C# 8.0 array slicing to logically separate first name(s) and last name.

        private string LastName;
        public string lastName
        {
            get { return this.LastName; }
            private set
            { 
                this.LastName = value.Split(" ")[^1];
            }
        }

        private string FirstName;
        public string firstName
        {
            get { return this.FirstName; }
            private set
            {
                this.FirstName = string.Join(" ", value.Split(" ")[0..^1]);
            }
        }

        public Name (string name)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Split(" ").Length < 2)
                throw new Exception($"The name '{name}' breaks a functional requirement:\n   Must have at least one given name [and one last name].");
            if (name.Split(" ").Length > 4)
                throw new Exception($"The name '{name}' breaks a functional requirement:\n   May have up to three given names [and one last name].");

            this.lastName = name;
            this.firstName = name;
        }

        public override string ToString ()
        {
            return (!String.IsNullOrEmpty(firstName) ? firstName + " " : "") + lastName;
        }

        public int CompareTo (Name other)
        {
            if (other == null)
                return 1;
            else
            {
                // Functional requirement: compare first name(s) when last name has equality.
                if (this.lastName.Equals(other.lastName))
                    return this.firstName.CompareTo(other.firstName);
                else
                    return this.lastName.CompareTo(other.lastName);
            }
        }

        public bool Equals (Name other)
        {
            if (other == null)
                return false;
            else
            {
                // Functional requirement: check first name(s) for equality when last name has equality.
                if (this.lastName.Equals(other.lastName))
                    return this.firstName.Equals(other.firstName);
                else
                    return this.lastName.Equals(other.lastName);
            }
        }
    }
}