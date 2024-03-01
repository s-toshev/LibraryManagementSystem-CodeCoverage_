using LibraryManagementSystem;

namespace LibraryManagementTest
{
    [TestFixture]
    public class LibraryTests
    {
        private Library _library;

        [SetUp]
        public void SetUp()
        {
            this._library = new Library();
        }



        [Test]
        public void AddBook_ShouldAddABookWhenCorrectDataPassed()
        {
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = false
            };

            //Act
            _library.AddBook(newBook);
            var getBooks = _library.GetAllBooks().FirstOrDefault(newBook => newBook.Id == 1);
            var allBooks = _library.GetAllBooks();
            //Assert
            Assert.NotNull(getBooks);
            Assert.That(allBooks.Count(), Is.EqualTo(1));   

            Assert.AreEqual(getBooks.Title, newBook.Title);
            Assert.AreEqual(getBooks.Author, newBook.Author);
            Assert.AreEqual(getBooks.Id, newBook.Id);
            Assert.False(getBooks.IsCheckedOut);

            Assert.That(getBooks, Is.EqualTo(newBook));



        }

        [Test]
        public void CheckOutBook_ShouldCheckOutABookWhenCorrectDataPassed()
        {
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = false
            };

            //Act
            _library.AddBook(newBook);
         
            _library.CheckOutBook(newBook.Id);

            //Assert
            Assert.True(newBook.IsCheckedOut);



        }


        [Test]
        public void CheckOutBook_ShouldReturnFalseWhenBookNotExist()
        {
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = true
            };

            _library.AddBook(newBook);

            int fakeId = 3;

            //Act
           

            var result = _library.CheckOutBook(fakeId);

            //Assert
            Assert.IsFalse(result);


        }


        [Test]
        public void CheckOutBook_ShouldReturnFalseWhenBookIsAlreadyCheckedOut()
        {
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = true
            };


            //Act
            _library.AddBook(newBook);
            var getBooks = _library.GetAllBooks().FirstOrDefault(newBook => newBook.Id == 1);
            Assert.NotNull(getBooks);
            Assert.That(getBooks, Is.EqualTo(newBook));

            var result = _library.CheckOutBook(newBook.Id);

            //Assert
            Assert.IsFalse(result);


        }

        [Test]
        public void ReturnBook_ShouldReturnFalseIFBookDoesNotExist()
        {
            //Arrange
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = true
            };

            _library.AddBook(newBook);

            int fakeId = 33;

            //Act
            var result = _library.ReturnBook(fakeId);

            //Assert
            Assert.IsFalse(result);

        }




        [Test]
        public void ReturnBook_ShouldReturnFalseIFBookNotCheckedOut()
        {
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = false
            };

            //Act
            _library.AddBook(newBook);
            var result = _library.ReturnBook(newBook.Id);

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void ReturnBook_ShouldReturnFalseIFBookCanBeCheckedOut()
        {
            //Arrarnge
            var newBook = new Book()
            {
                Id = 1,
                Title = "A title",
                Author = "New Author",
                IsCheckedOut = true
            };

            //Act
            _library.AddBook(newBook);
            var result = _library.ReturnBook(newBook.Id);

            //Assert
            Assert.IsTrue(result);

        }

    }
}
