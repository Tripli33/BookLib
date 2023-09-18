using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects.Book;
using Shared.DataTransferObjects.CustomerBook;

namespace Service
{
    public class CustomerBookService : ICustomerBookService
    {
        private readonly IRepositoryManager _repositoryManager;
        public CustomerBookService (IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task AddCustomerBook(long customerId, CustomerBookDto book)
        {
            if (!await _repositoryManager.Customer.CustomerExists(customerId))
            throw new CustomerNotFoundException(customerId);
            if (!await _repositoryManager.Book.BookExists(book.BookId))
            throw new BookNotFoundException(book.BookId);
            if (await _repositoryManager.CustomerBook.CustomerBookExists(customerId, book.BookId))
            throw new CustomerBookConflictException(customerId, book.BookId);
            _repositoryManager.CustomerBook.AddCustomerBook(customerId, book);
        }

        public async Task DeleteCustomerBook(long customerId, long bookId)
        {
            if (!await _repositoryManager.Customer.CustomerExists(customerId))
            throw new CustomerNotFoundException(customerId);
            if (!await _repositoryManager.Book.BookExists(bookId))
            throw new BookNotFoundException(bookId);
            _repositoryManager.CustomerBook.DeleteCustomerBook(customerId, bookId);
        }

        public async Task<IEnumerable<ExtendBookDto>> GetAllCustomerBooks(long customerId)
        {
            if (!await _repositoryManager.Customer.CustomerExists(customerId))
            throw new CustomerNotFoundException(customerId);
            return await _repositoryManager.CustomerBook.GetAllCustomerBooks(customerId);
        }

        public async Task<ExtendBookDto> GetCustomerBook(long customerId, long bookId)
        {
            if (!await _repositoryManager.Customer.CustomerExists(customerId))
            throw new CustomerNotFoundException(customerId);
            if (!await _repositoryManager.Book.BookExists(bookId))
            throw new BookNotFoundException(bookId);
            return await _repositoryManager.CustomerBook.GetCustomerBook(customerId, bookId);
        }
    }
}