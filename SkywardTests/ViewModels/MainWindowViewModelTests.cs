using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyward.Models;
using Skyward.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward.ViewModels.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        AppContext wpfContext = new AppContext();
        [TestMethod()]
        public void Authorization()
        {
            User user = new User();
            user.Login = "admin";
            user.Password = "123";
            User userTest = wpfContext.Users.FirstOrDefault(p => p.Login == user.Login && p.Password == user.Password);
            bool check = false;
            if (userTest != null)
            {
                check = true;
                Assert.IsTrue(check);
            }
            else
            {
                Assert.IsFalse(check);
            }
        }
    }
}