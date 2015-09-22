using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using web.Controllers;

namespace web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;

            Assert.AreEqual("Indexku", result.ViewName);
        }
    }
}
