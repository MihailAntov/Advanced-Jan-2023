using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        List<Book> books;
        public Library(params Book[] books)
        {
            Array.Sort(books);
            //Array.Sort(books, new BookComparator());
            this.books = books.ToList();
            
        }
        
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {
            int currentIndex = -1;
            List<Book> books;
            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose(){}

            public bool MoveNext()
            {
                currentIndex++;
                if(currentIndex == books.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            
        }

    }
}
