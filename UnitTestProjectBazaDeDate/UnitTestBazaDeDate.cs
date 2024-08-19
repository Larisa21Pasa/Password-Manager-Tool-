using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BazaDeDate.Tables;
namespace UnitTestProjectBazaDeDate
{
    [TestClass]
    public class UnitTestBazaDeDate
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            CreateTable.CreatePasswordsTable();
            CreateTable.CreateUsersTable();
        }


        [TestMethod]
        public void TestUserTable_1()
        {
            UsersTable ut = new UsersTable();
            try
            {
                ut.Add("razvan", "1205");
                Assert.Fail();
            }
            catch(Exception ex)
            {
            }
        }

        [TestMethod]
        public void TestUserTable_2()
        {
            UsersTable ut = new UsersTable();
            Assert.AreEqual(true, ut.UpdateToken("razvan", "1212"));
        }

        [TestMethod]
        public void TestUserTable_3()
        {
            UsersTable ut = new UsersTable();
            Assert.AreEqual(false, ut.CheckHash("danu", "1234"));
        }

        [TestMethod]
        public void TestUserTable_4()
        {
            UsersTable ut = new UsersTable();
            Assert.AreEqual(false, ut.CheckHash("andrei", "4321"));
        }

        [TestMethod]
        public void TestPasswordTable_1()
        {
            PasswordsTable ps = new PasswordsTable();
            Assert.AreEqual(true, ps.Add(new BazaDeDate.DataClasses.User("om"), new BazaDeDate.DataClasses.Password("email", "domain", "pass", "domainUser")));
            Assert.AreEqual(true, ps.Delete(new BazaDeDate.Option.DeleteOptions("om", "email", "domain", "pass"), new BazaDeDate.DataClasses.User("om")));
        }

        [TestMethod]
        public void TestPasswordTable_2()
        {
            PasswordsTable ps = new PasswordsTable();

            Assert.AreEqual(false, ps.Delete(new BazaDeDate.Option.DeleteOptions("unknown", "emailasd", "domain", "pass"), new BazaDeDate.DataClasses.User("unknown")));
        }

        [TestMethod]
        public void TestPasswordTable_3()
        {
            PasswordsTable ps = new PasswordsTable();
            try
            {
                ps.Add(new BazaDeDate.DataClasses.User("danutz"), new BazaDeDate.DataClasses.Password("budu@gmail.com", "ac", "passwo", "domainUser"));
                Assert.Fail();
            }
            catch (Exception ex)
            { }
        }

        [TestMethod]
        public void TestPasswordTable_4()
        {
            PasswordsTable ps = new PasswordsTable();

            Assert.AreEqual(false, ps.Delete(new BazaDeDate.Option.DeleteOptions("danutz", "emailasd", "domain", "pass"), new BazaDeDate.DataClasses.User("unknown")));
        }

    }
}
