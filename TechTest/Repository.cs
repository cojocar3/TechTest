using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    public class Repository : IRepository<Storeable>
    {
        private IEnumerable<Storeable> _storeables;

        public Repository(IEnumerable<Storeable> storeables)
        {
            _storeables = storeables;
        }

        public IEnumerable<Storeable> All()
        {
            return _storeables;
        }

        public void Delete(IComparable id)
        {
            _storeables = _storeables.Where(x => !x.Id.Equals(id));
        }

        public Storeable FindById(IComparable id)
        {
            return _storeables.First(x => x.Id.Equals(id));
        }

        public void Save(Storeable item)
        {
            _storeables = _storeables.Concat(new Storeable[] { item });
        }
    }
}
