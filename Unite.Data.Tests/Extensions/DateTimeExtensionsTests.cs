using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unite.Data.Extensions;

namespace Unite.Data.Tests.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod("'RelativeFrom' should calculate relative day")]
        public void RelativeFrom_WithDates()
        {
            DateTime? referenceDate = new DateTime(2020, 01, 01, 17, 32, 26);
            DateTime? eventDate = new DateTime(2020, 01, 07, 09, 10, 31);
            int? eventDay = eventDate.RelativeFrom(referenceDate);

            Assert.AreEqual(6, eventDay);
        }

        [TestMethod("'RelativeFrom' should return null if any date is not set")]
        public void RelativeFrom_WithoutDates()
        {
            DateTime? referenceDate1 = new DateTime(2020, 01, 01, 17, 32, 26);
            DateTime? eventDate1 = null;
            var eventDay1 = eventDate1.RelativeFrom(referenceDate1);

            Assert.IsNull(eventDay1);


            DateTime? referenceDate2 = null;
            DateTime? eventDate2 = new DateTime(2020, 01, 07, 09, 10, 31);
            var eventDay2 = eventDate2.RelativeFrom(referenceDate2);

            Assert.IsNull(eventDay2);


            DateTime? referenceDate3 = null;
            DateTime? eventDate3 = null;
            var eventDay3 = eventDate3.RelativeFrom(referenceDate3);

            Assert.IsNull(eventDay3);
        }
    }
}
