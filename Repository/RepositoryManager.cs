using Contracts;
using Microsoft.VisualBasic;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IPublisherRepository> _publisherRepository;
    private readonly Lazy<ICustomerRepository> _customerRepository;
    private readonly Lazy<ICustomerBookRepository> _customerBookRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _bookRepository = new Lazy<IBookRepository>(() =>
        new BookRepository(context));
        _authorRepository = new Lazy<IAuthorRepository>(() =>
        new AuthorRepository(context));
        _publisherRepository = new Lazy<IPublisherRepository>(() =>
        new PublisherRepository(context));
        _customerRepository = new Lazy<ICustomerRepository>(() =>
        new CustomerRepository(context));
        _customerBookRepository = new Lazy<ICustomerBookRepository>(() =>
        new CustomerBookRepository(context));
    }

    public IBookRepository Book => _bookRepository.Value;

    public IAuthorRepository Author => _authorRepository.Value;

    public IPublisherRepository Publisher => _publisherRepository.Value;

    public ICustomerRepository Customer => _customerRepository.Value;

    public ICustomerBookRepository CustomerBook => _customerBookRepository.Value;
}