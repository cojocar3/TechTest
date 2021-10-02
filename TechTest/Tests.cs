using NUnit.Framework;
using System.Linq;

namespace Interview
{
    [TestFixture]
    public class Tests
    {
        private Repository _repository;
        private Storeable[] _storeables;

        [SetUp]
        public void SetUp()
        {
            _storeables = new Storeable[]
            {
                new Storeable {Id = 1},
                new Storeable {Id = 2},
                new Storeable {Id = 3},
                new Storeable {Id = 4},
                new Storeable {Id = 5}
            };
            _repository = new Repository(_storeables);
        }

        [Test]
        public void GetAllStoreables()
        {
            var result = _repository.All();

            Assert.IsFalse(result.Count() != _storeables.Count(), "All items have not been retrieved");
        }

        [Test]
        public void DeleteStoreable()
        {
            var storeable = new Storeable { Id = 1 };
            _repository.Delete(storeable.Id);

            var storeables = _repository.All();

            Assert.IsFalse(storeables.Any(x => x.Id.Equals(storeable.Id)), "Item has not been deleted");
        }

        [Test]
        public void FindStoreable()
        {
            var storeable = new Storeable { Id = 1 };
            var result = _repository.FindById(storeable.Id);

            Assert.IsFalse(!result.Id.Equals(storeable.Id), "Item has not been found");
        }

        [Test]
        public void SaveStoreable()
        {
            var storeable = new Storeable { Id = 6 };
            _repository.Save(storeable);

            var storeables = _repository.All();

            Assert.IsFalse(!storeables.Contains(storeable), "Item has not been saved");
        }
    }
}