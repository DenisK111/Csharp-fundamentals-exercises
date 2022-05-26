namespace Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class Lake<T> : IEnumerable<T>
    {
        T[] stones;

        public Lake(params T[] input)
        {
            this.stones = input;
        }

        public T[] Stones => this.stones;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (i % 2 ==0)
                {
                    yield return stones[i];
                }
            }

            for (int i = stones.Length - 1; i >= 0; i--)
            {
                if (i%2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}