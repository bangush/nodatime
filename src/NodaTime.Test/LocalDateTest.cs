﻿#region Copyright and license information
// Copyright 2001-2009 Stephen Colebourne
// Copyright 2009-2011 Jon Skeet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using NUnit.Framework;

namespace NodaTime.Test
{
    [TestFixture]
    public class LocalDateTest
    {
        [Test]
        public void Addition_WithPeriod()
        {
            LocalDate start = new LocalDate(2010, 6, 19);
            Period period = Period.FromMonths(3) + Period.FromDays(10);
            LocalDate expected = new LocalDate(2010, 9, 29);
            Assert.AreEqual(expected, start + period);
        }

        [Test]
        public void Addition_TruncatesOnShortMonth()
        {
            LocalDate start = new LocalDate(2010, 1, 30);
            Period period = Period.FromMonths(1);
            LocalDate expected = new LocalDate(2010, 2, 28);
            Assert.AreEqual(expected, start + period);
        }

        [Test]
        public void Addition_WithNullPeriod_ThrowsArgumentNullException()
        {
            LocalDate date = new LocalDate(2010, 1, 1);
            // Call to ToString just to make it a valid statement
            Assert.Throws<ArgumentNullException>(() => (date + (Period)null).ToString());
        }

        [Test]
        public void Subtraction_WithPeriod()
        {
            LocalDate start = new LocalDate(2010, 9, 29);
            Period period = Period.FromMonths(3) + Period.FromDays(10);
            LocalDate expected = new LocalDate(2010, 6, 19);
            Assert.AreEqual(expected, start - period);
        }

        [Test]
        public void Subtraction_TruncatesOnShortMonth()
        {
            LocalDate start = new LocalDate(2010, 3, 30);
            Period period = Period.FromMonths(1);
            LocalDate expected = new LocalDate(2010, 2, 28);
            Assert.AreEqual(expected, start - period);
        }

        [Test]
        public void Subtraction_WithNullPeriod_ThrowsArgumentNullException()
        {
            LocalDate date = new LocalDate(2010, 1, 1);
            // Call to ToString just to make it a valid statement
            Assert.Throws<ArgumentNullException>(() => (date - (Period)null).ToString());
        }

        [Test]
        public void WithDayOfMonth_Simple()
        {
            LocalDate start = new LocalDate(2010, 3, 15);
            LocalDate end = start.WithDayOfMonth(20);
            Assert.AreEqual(new LocalDate(2010, 3, 20), end);
        }

        [Test]
        public void WithDayOfMonth_MakingDayInvalid()
        {
            LocalDate date = new LocalDate(2010, 2, 25);
            Assert.Throws<ArgumentOutOfRangeException>(() => date.WithDayOfMonth(30));
        }

        [Test]
        public void WithMonthOfYear_Simple()
        {
            LocalDate start = new LocalDate(2010, 3, 15);
            LocalDate end = start.WithMonthOfYear(8);
            Assert.AreEqual(new LocalDate(2010, 8, 15), end);
        }

        [Test]
        public void WithMonthOfYear_MakingDayInvalid()
        {
            LocalDate start = new LocalDate(2010, 3, 30);
            LocalDate end = start.WithMonthOfYear(2);
            Assert.AreEqual(new LocalDate(2010, 2, 28), end);
        }

        [Test]
        public void WithYear_Simple()
        {
            LocalDate start = new LocalDate(2012, 3, 15);
            LocalDate end = start.WithYear(2012);
            Assert.AreEqual(new LocalDate(2012, 3, 15), end);
        }

        [Test]
        public void WithYear_MakingDayInvalid()
        {
            LocalDate start = new LocalDate(2012, 2, 29);
            LocalDate end = start.WithYear(2010);
            Assert.AreEqual(new LocalDate(2010, 2, 28), end);
        }

    }
}
