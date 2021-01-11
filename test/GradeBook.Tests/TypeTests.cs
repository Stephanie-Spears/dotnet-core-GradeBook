using System;
using Xunit;

namespace GradeBook.Tests
{
	public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
	    private int count = 0;

	    [Fact]
	    public void WriteLogDelegateCanPointToMethod()
	    {
		    WriteLogDelegate log = ReturnMessage;
		    log += ReturnMessage;
		    log += IncrementCount;

		    var result = log("Hello!");

	    }

	    string IncrementCount(string message)
	    {
		    count++;
		    return message.ToLower();
	    }

	    string ReturnMessage(string message)
	    {
		    count++;
		    return message;
	    }

	    [Fact]
	    public void ValueTypesAlsoPassByValue()
	    {
		    var x = GetInt();
		    SetInt(ref x);
		    Assert.Equal(42, x);
	    }

	    private void SetInt(ref int z)
	    {
		    z = 42;
	    }

	    private int GetInt()
	    {
		    return 3;
	    }


	    [Fact]
	    public void StringsBehaveLikeValueTypes()
	    {
		    string name = "Stephanie";
		    var upper = MakeUpperCase(name);

			Assert.Equal("Stephanie", name);
			Assert.Equal("STEPHANIE", upper);
	    }

	    private string MakeUpperCase(string parameter)
	    {
		    return parameter.ToUpper();
	    }


	    [Fact]
	    public void CSharpCanPassByRef()
	    {
		    // arrange
		    var book1 = GetBook("Book 1");

		    // act
		    GetBookSetName(out book1, "New Name");


		    // assert
		    Assert.Equal("New Name", book1.Name);

	    }

	    private void GetBookSetName(out Book book, string name)
	    {
		    book = new Book(name);
	    }


	    [Fact]
	    public void CSharpIsPassedByValue()
	    {
		    // arrange
		    var book1 = GetBook("Book 1");

		    // act
		    GetBookSetName(book1, "New Name");


		    // assert
		    Assert.Equal("Book 1", book1.Name);

	    }

	    private void GetBookSetName(Book book, string name)
	    {
		    book = new Book(name);
	    }


	    [Fact]
	    public void CanSetNameFromReference()
	    {
		    // arrange
		    var book1 = GetBook("Book 1");

		    // act
		    SetName(book1, "New Name");


		    // assert
		    Assert.Equal("New Name", book1.Name);

	    }

	    private void SetName(Book book, string name)
	    {
		    book.Name = name;
	    }



	    [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");


            // act



            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }


        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
	        // arrange
	        var book1 = GetBook("Book 1");
	        var book2 = book1;


	        // act



	        // assert
	        Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
	        return new Book(name);
        }
    }
}
