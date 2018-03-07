using Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var urlTargetSite = "http://localhost:49626/";
            var id = "7";
            var result = CheckoutInterface.DeleteOrderItem(urlTargetSite, id);
        }
    }
}
