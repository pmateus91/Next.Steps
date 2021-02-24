using System.Collections.Generic;
using System;



namespace Next.Steps.Domain.ValueTypes
{
    public class Hobby : ValueObject<Hobby>
    {
        public string HobbyName { get; }
        public string Description { get; }

        protected Hobby()
        {
        }

        public Hobby(string hobbyname, string description)
        {
            HobbyName = hobbyname;
            Description = description;
        }

        protected override bool EqualsCore(Hobby other)
        {
            return HobbyName == other.HobbyName && Description == other.Description;
        }

        protected override int GetHashCodeCore()
        {
            return HobbyName.GetHashCode() ^ Description.GetHashCode();
        }
     
    }
}
