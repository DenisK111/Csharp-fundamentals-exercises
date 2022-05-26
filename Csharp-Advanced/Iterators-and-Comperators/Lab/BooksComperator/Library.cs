namespace IteratorsAndComparators
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using System.Collections;

    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = books.ToList();
            Books.Sort(new BookComparator());
        }
        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            
            var enumerator = new LibraryIterator(Books);
            return enumerator;

        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        IEnumerator<Book> IEnumerable<Book>.GetEnumerator() => this.GetEnumerator();


        

        private class LibraryIterator : IEnumerator<Book>
        {
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            int index = -1;
            public Book Current => books[index];

            List<Book> books;

            object IEnumerator.Current => Current;

            public void Dispose()
            {                
            }

            public bool MoveNext()
            {
                return ++index < books.Count;
            }

            public void Reset()
            {
                index = -1;
            }
        }


    }
}