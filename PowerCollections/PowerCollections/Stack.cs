using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Wintellect.PowerCollections
{
    /// <summary>
    /// <see cref="Wintellect.PowerCollections.Stack{T}"/> is a collection organized like a stack data structure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        private T[] Array; // stack
        /// <summary>
        /// Max count of elements that stack can contain
        /// </summary>
        public int Capacity { get { return Array.Length; } } // максимальный размер стека

        private int count = 0; // текущее число элементов в стеке

        /// <summary>
        /// Current count of elements in stack
        /// </summary>
        public int Count { get { return count; } }

        /// <summary>
        /// Creates new stack with specified capacity
        /// </summary>
        /// <param name="count">Stack capacity</param>
        public Stack(int count = 100)
        {
            this.Array = new T[count];
        }

        /// <summary>
        /// Puts element on the top of stack
        /// </summary>
        /// <param name="item">Element to push</param>
        /// <exception cref="Exception"></exception>
        public void Push(T item)
        {
            if (this.count == this.Capacity)
            {
                throw new Exception("Стек переполнен");
            }

            this.Array[this.count++] = item;
        }

        /// <summary>
        /// Returns top element of stack without removing it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T Top()
        {
            if (this.count == 0)
            {
                throw new Exception("Стек пуст");
            }

            return this.Array[this.count - 1];
        }

        /// <summary>
        /// Returns top element of stack and removes it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public T Pop()
        {
            if (count == 0)
            {
                throw new Exception("Стек пуст");
            }

            T returnValue = this.Top();

            this.Array = this.Array.Where((value, index) => index != this.count).ToArray();
            this.count--;

            return returnValue;
        }

        /// <summary>
        /// Returns Enumerator that iterates stack from top to bottom
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (count == 0)
                yield break;

            for (int i = count; i > 0; i--)
                yield return Array[i - 1];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}