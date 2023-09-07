using Contracts;
using Service.Contracts;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IPublisherService> _publisherService;
    private readonly Lazy<IAuthorService> _authorService;
    private readonly Lazy<ICustomerService> _customerService;
    private readonly Lazy<ICustomerBookService> _customerBookService;
    public ServiceManager (IRepositoryManager repositoryManager)
    {
        _bookService = new Lazy<IBookService>(() => 
        new BookService(repositoryManager));
        _publisherService = new Lazy<IPublisherService>(() => 
        new PublisherService(repositoryManager));
        _authorService = new Lazy<IAuthorService>(() => 
        new AuthorService(repositoryManager));
        _customerService = new Lazy<ICustomerService>(() =>
        new CustomerService(repositoryManager));
        _customerBookService = new Lazy<ICustomerBookService>(() =>
        new CustomerBookService(repositoryManager));
    }
    public IBookService BookService => _bookService.Value;

    public IPublisherService PublisherService => _publisherService.Value;

    public IAuthorService AuthorService => _authorService.Value;

    public ICustomerService CustomerService => _customerService.Value;

    public ICustomerBookService CustomerBookService => _customerBookService.Value;
}