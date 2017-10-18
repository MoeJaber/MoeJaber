using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_3_Jaber_Mouhamad;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AssertDecrypt()
        {

            string expected = "Ontario";

            main sol = new main();
            string[] number = { "7.1" };

            string[] array = number[0].Split(new char[] { '.' }).Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            var res = sol.decrypt(array);

            // assert  
            string returned = res.Item1;
            Assert.AreEqual(expected, returned, "", "Converted 7 to Ontario correctly");

        }
    }
}
