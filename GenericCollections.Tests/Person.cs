using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections.Tests
{
    public class Person : IEquatable<Person>
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int Age { get; set; }

        public bool Equals(Person other)
            => other != null &&
               this.FirstName.Equals(other.FirstName) &&
               this.SecondName.Equals(other.SecondName) &&
               this.Age.Equals(other.Age);

        public override bool Equals(object other)
        {
            return this.Equals(other as Person);
        }

        public override int GetHashCode()
        {
            int hash = FirstName.GetHashCode()
                + SecondName.GetHashCode()
                + Age.GetHashCode();

            return hash;
        }
    }
}
