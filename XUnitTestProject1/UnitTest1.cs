using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebApplication2.Controllers;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void Test1()
        {
            
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            System.Diagnostics.Debug.WriteLine(path);


            _output.WriteLine("Starting test in " + path);
            //var ActionResult 
            var log = new MyLogger<HomeController>(_output);
            var controller = new HomeController(log);

            IActionResult ret = controller.Index();
            Assert.IsType<ViewResult>(ret);
        }

        [Fact]
        public void TestSave()
        {
            var controller = new HomeController(null);
            JsonResult ret = controller.Save("name", new List<string>() { 
                "aaa", "bbb" 
            });
            System.Diagnostics.Debug.WriteLine(ret);
            Assert.True((bool)ret.GetPropertyValue("success") == false);
        }
    }

    public class MyLogger<T> : ILogger<T>, IDisposable
    {
        private ITestOutputHelper _output;

        public MyLogger(ITestOutputHelper output)
        {
            _output = output;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _output.WriteLine(state.ToString());
        }
        public void Dispose()
        {

        }
    }

    public static class JsonExtensions
    {
        public static object GetPropertyValue(this JsonResult json, string propertyName)
        {
            return json.Value.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public).GetValue(json.Value, null);
        }
    }
}
