using GenerareParola.Generator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProjectBazaDeDate
{
    [TestClass]
    public class UnitTestGenerareParola
    {
        bool isAllLower(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }

        bool isAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && Char.IsLower(input[i]))
                    return false;
            }
            return true;
        }

        bool isAllLetters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]))
                    return false;
            }
            return true;
        }

        bool isAllNumbers(string input)
        {
            int a;
            for(int i = 0; i<input.Length;i+=2)
            {
                if(!int.TryParse(input.Substring(i, 2), out a))
                {
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void TestMethodGenerareLower()
        {
            PasswordGenerator gp = new PasswordGenerator();

            gp.SetLowerAlpha();
            string str = gp.Generate();
            Assert.AreEqual(true, isAllLower(str));
        }

        [TestMethod]
        public void TestMethodGenerateUpper()
        {
            PasswordGenerator gp = new PasswordGenerator();

            gp.SetUpperAlpha();
            string str = gp.Generate();
            Assert.AreEqual(true, isAllUpper(str));
        }

        [TestMethod]
        public void TestMethodGenerateLetters()
        {
            PasswordGenerator gp = new PasswordGenerator();

            gp.SetUpperAlpha();
            gp.SetLowerAlpha();

            string str = gp.Generate();
            Assert.AreEqual(true, isAllLetters(str));
        }

        [TestMethod]
        public void TestMethodGenerateNumericSpecial()
        {
            PasswordGenerator gp = new PasswordGenerator();

            gp.SetNumeric();
            gp.SetSpecial();

            string str = gp.Generate();
            Assert.AreEqual(true, !isAllLetters(str));
        }

        [TestMethod]
        public void TestMethodGenerateLength()
        {
            PasswordGenerator gp = new PasswordGenerator();
            int length = 8;
            gp.SetLength(length);

            string str = gp.Generate();
            Assert.AreEqual(length, str.Length);
        }

        [TestMethod]
        public void TestMethodGenerate_1()
        {
            PasswordGenerator gp = new PasswordGenerator();
            int length = 10;
            gp.SetLength(length);
            gp.SetLowerAlpha();
            gp.SetUpperAlpha();

            string str = gp.Generate();

            Assert.AreEqual(length, str.Length);
            Assert.AreEqual(true, isAllLetters(str));
        }

        [TestMethod]
        public void TestMethodGenerate_2()
        {
            PasswordGenerator gp = new PasswordGenerator();
            int length = 10;
            gp.SetLength(length);
            gp.SetNumeric();
            gp.SetSpecial();

            string str = gp.Generate();

            Assert.AreEqual(length, str.Length);
            Assert.AreEqual(true, !isAllLetters(str));
        }

        [TestMethod]
        public void TestMethodGenerate_3()
        {
            PasswordGenerator gp = new PasswordGenerator();
            gp.SetNumeric();
        
            string str = gp.Generate();

            Assert.AreEqual(true, isAllNumbers(str));
        }

        [TestMethod]
        public void TestMethodGenerate_4()
        {
            PasswordGenerator gp = new PasswordGenerator();
            gp.SetNumeric();

            string str = gp.Generate();

            Assert.AreEqual(false, isAllLetters(str));
        }

        [TestMethod]
        public void TestMethodGenerate_5()
        {
            PasswordGenerator gp = new PasswordGenerator();
            gp.SetSpecial();

            string str = gp.Generate();

            Assert.AreEqual(false, isAllLetters(str));
            Assert.AreEqual(false, isAllNumbers(str));
        }

        [TestMethod]
        public void TestMethodGenerate_6()
        {
            PasswordGenerator gp = new PasswordGenerator();
            gp.SetSpecial();
            gp.SetLength(12);

            string str = gp.Generate();

            Assert.AreEqual(false, isAllLetters(str));
            Assert.AreEqual(false, isAllNumbers(str));
            Assert.AreEqual(12, str.Length);
        }

        [TestMethod]
        public void TestMethodGenerate_7()
        {
            PasswordGenerator gp = new PasswordGenerator();
            gp.SetLowerAlpha();
            gp.SetUpperAlpha();

            string str = gp.Generate();

            Assert.AreEqual(false, isAllNumbers(str));

        }
    }
}
