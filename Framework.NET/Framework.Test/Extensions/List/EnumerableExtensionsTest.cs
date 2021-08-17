using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Framework.Extensions.List;
using NUnit.Framework;

namespace Framework.Test.Extensions.List
{
    public class EnumerableExtensionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Group_WhenGroup_ThenHasGroups()
        {
            var list = Enumerable.Range(1, 5).Select(item => new Task<int>(() => item));
            var groups = list.Group(2);
            groups.Should().HaveCount(3);
        }
    }
}