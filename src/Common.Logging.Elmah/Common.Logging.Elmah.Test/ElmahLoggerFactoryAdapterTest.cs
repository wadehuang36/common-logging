using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Common.Logging.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Logging.Elmah.Test
{
    [TestClass]
    public class ElmahLoggerFactoryAdapterTest
    {
        [TestMethod]
        public void U__ElmahLogger__MinLevel__Info()
        {
            NameValueCollection collections = new NameValueCollection();
            collections["MinLevel"] = "Info";
            ElmahLoggerFactoryAdapter lfa = new ElmahLoggerFactoryAdapter(collections);

            var logger = lfa.GetLogger("");
            logger.Error("Test");
            var list = new List<global::Elmah.ErrorLogEntry>();
            global::Elmah.ErrorLog.GetDefault(null).GetErrors(0, 20, list);

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void U__ElmahLogger__MinLevel__Error()
        {
            NameValueCollection collections = new NameValueCollection();
            collections["MinLevel"] = "6";
            ElmahLoggerFactoryAdapter lfa = new ElmahLoggerFactoryAdapter(collections);

            var logger = lfa.GetLogger("");
            logger.Error("Test");

            var list = new List<global::Elmah.ErrorLogEntry>();
            global::Elmah.ErrorLog.GetDefault(null).GetErrors(0, 20, list);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void U__ElmahLogger__Config()
        {
            Common.Logging.ILog logger = Common.Logging.LogManager.GetCurrentClassLogger();

            logger.Error("Test");

            var list = new List<global::Elmah.ErrorLogEntry>();
            global::Elmah.ErrorLog.GetDefault(null).GetErrors(0, 20, list);

            Assert.AreEqual(0, list.Count);
        }
    }
}