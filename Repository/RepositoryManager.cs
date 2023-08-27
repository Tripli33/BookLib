using Contracts;
using Microsoft.VisualBasic;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IPublisherRepository> _publisherRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _bookRepository = new Lazy<IBookRepository>(() =>
        new BookRepository(context));
        _authorRepository = new Lazy<IAuthorRepository>(() =>
        new AuthorRepository(context));
        _publisherRepository = new Lazy<IPublisherRepository>(() =>
        new PublisherRepository(context));
    }

    public IBookRepository Book => _bookRepository.Value;

    public IAuthorRepository Author => _authorRepository.Value;

    public IPublisherRepository Publisher => _publisherRepository.Value;
}