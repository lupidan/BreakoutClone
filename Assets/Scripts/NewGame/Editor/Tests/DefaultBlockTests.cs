using NUnit.Framework;
using NSubstitute;

namespace Game
{
    [TestFixture]
    public class DefaultBlockTests
    {
        private DefaultBlock block;

        [SetUp]
        public void SetUp()
        {
            block = new DefaultBlock();
        }

        [TearDown]
        public void TearDown()
        {
            block = null;
        }

        [Test]
        public void TestDestroyDoesNotThrowAnExceptionIfDestroyableIsNull()
        {
            block.destroyable = null;
            block.Destroy();
        }

        [Test]
        public void TestDestroyCallsDestroyableDestroy()
        {
            Destroyable mockDestroyable = Substitute.For<Destroyable>();
            block.destroyable = mockDestroyable;
            block.Destroy();

            mockDestroyable.Received().Destroy();
        }

    }
}
