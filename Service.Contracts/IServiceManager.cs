namespace Service.Contracts;

public interface IServiceManager
{
    public IBookService BookService { get; }
    public IPublisherService PublisherService { get; }
    public IAuthorService AuthorService { get; }
}