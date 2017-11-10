using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_3_Jaber_Mouhamad;
using System.Linq;
/**
 * Author : Mouhamad Jaber
 * Assignment 3
 * */
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod] //testing method in main.cs
        public void AssertDecrypt()
        {
            //declared expected value as string
            string expected = "Ontario";
            //declare an array of strings
            string[] number = { "7.1" };

            //access the main object
            main sol = new main();
   
            //split the array on periods and stored into a new array
            string[] array = number[0].Split(new char[] { '.' }).Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            //pass in the array to the method decrypt and stored result into variable res
            var res = sol.decrypt(array);

            // assert  
            string returned = res.Item1;
            //check is the expected result equals the actual result
            Assert.AreEqual(expected, returned, "", "Converted 7 to Ontario correctly");


            string expectedProvince = "Yukon";
            string returnedProvince = sol.provinceDecrypt("ff7b00ff");
            Assert.AreEqual(expectedProvince, returnedProvince, "", "Converted mouseclick to correct province");

        }
        [TestMethod] //testing method in main.cs
        public void AssertProvinceDecrypt()
        {
         
            //access the main object
            main sol = new main();

            //declared expected value as string
            string expectedProvince = "Yukon";
            //stored returned value in string
            string returnedProvince = sol.provinceDecrypt("ff7b00ff");
            //Assert the returned value equals the expected value
            Assert.AreEqual(expectedProvince, returnedProvince, "", "Converted mouseclick to correct province");

        }
    }
}
