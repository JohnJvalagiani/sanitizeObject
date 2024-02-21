using sanitizeObject;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ObjectSanitizer _objectSanitizer;
        public UnitTest1(ObjectSanitizer objectSanitizer)
        {
            _objectSanitizer=objectSanitizer;
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}