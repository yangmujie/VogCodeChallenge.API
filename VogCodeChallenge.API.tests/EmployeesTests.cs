using System;
using Xunit;
using VogCodeChallenge.API;

namespace VogCodeChallenge.API.tests
{
    public class EmployeesTests
    {

        /// <summary>
        /// test the input number 0, expected 0
        /// </summary>
        [Fact]
        public void Test0()
        {

            Assert.Equal<object>(0, TESTModule.Module(0));
        }

        [Fact]
        public void Test1()
        {

            Assert.Equal<object>(1, TESTModule.Module(1));
        }

        [Fact]
        public void Test2()
        {

            Assert.Equal<object>(4, TESTModule.Module(2));
        }

        [Fact]
        public void Test3()
        {

            Assert.Equal<object>(9L, TESTModule.Module(3));
        }

        [Fact]
        public void Test4()
        {

            Assert.Equal<object>(12L, TESTModule.Module(4));
        }

        [Fact]
        public void TestMaxInt()
        {

            Assert.Equal<object>(6442450941, TESTModule.Module(2147483647));
        }

        [Fact]
        public void TestFloat()
        {

            Assert.Equal<object>(2.5f, TESTModule.Module(2.5f));
        }

        [Fact]
        public void TestOtherFloat()
        {

            Assert.Equal<object>(0.0, TESTModule.Module(1.0f));
        }
    }
}
