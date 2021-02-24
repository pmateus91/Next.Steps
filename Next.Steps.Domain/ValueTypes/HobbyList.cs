using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Next.Steps.Domain.ValueTypes
{
    public class HobbyList : ValueObject<HobbyList>, IEnumerable<Hobby>
    {
        private List<Hobby> _hobby { get; }

        public HobbyList(IEnumerable<Hobby> hobby)
        {
            _hobby = hobby.ToList();
        }

        protected override bool EqualsCore(HobbyList other)
        {
            return _hobby
                .OrderBy(x => x.HobbyName)
                .SequenceEqual(other._hobby.OrderBy(x => x.HobbyName));
        }

        protected override int GetHashCodeCore()
        {
            return _hobby.Count;
        }

        public IEnumerator<Hobby> GetEnumerator()
        {
            return _hobby.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }  
    }
}

