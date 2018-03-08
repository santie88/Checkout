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
            var id = "3";
            var quantity = 2;
            var result = CheckoutInterface.UpdateOrderItem(urlTargetSite, id, quantity);
        }
    }
}
