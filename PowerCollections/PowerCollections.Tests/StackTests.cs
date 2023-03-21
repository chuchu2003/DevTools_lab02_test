using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wintellect.PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void DefaultConstructorStack()
        {
            Stack<int> stack = new Stack<int>(1);

            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(1, stack.Capacity);
        }
        [TestMethod]
        public void CreatedStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void AfterPushItemStackIsNotEmpty()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void AfterPopItemStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(2);
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushElementToTheTopOfStack()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(2);
            stack.Push(9);
            stack.Push(5);
            Assert.AreEqual(5, stack.Top());
        }
        [TestMethod]
        public void PopElementFromTheTopOfStack()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(2);
            stack.Push(9);
            stack.Push(5);
            Assert.AreEqual(5, stack.Pop());
        }
        [TestMethod]
        public void TopDetectedElementFromTheTopOfStack()
        {
            Stack<int> stack = new Stack<int>(3);
            stack.Push(2);
            stack.Push(9);
            stack.Push(7);
            Assert.AreEqual(7, stack.Top());
        }

        [TestMethod]
        public void GetEnumeratorFromTopToBottom()
        {
            Stack<int> stack = new Stack<int>(3);
            IEnumerator numerator = stack.GetEnumerator();
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            numerator.MoveNext();
            Assert.AreEqual(1, numerator.Current);
            numerator.MoveNext();
            Assert.AreEqual(2, numerator.Current);
            numerator.MoveNext();
            Assert.AreEqual(3, numerator.Current);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Стек переполнен")]
        public void ExceptionStackOverflow()
        {
            Stack<bool> stack = new Stack<bool>(0);
            stack.Push(true);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(0, stack.Capacity);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Стек пуст")]
        public void WhenPopFromEmptyStack()
        {
            Stack<int> stack = new Stack<int>(2);
            Assert.AreEqual(5, stack.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Стек пуст")]
        public void WhenTopFromEmptyStack()
        {
            Stack<int> stack = new Stack<int>(2);
            Assert.AreEqual(5, stack.Top());
        }

    }

}
