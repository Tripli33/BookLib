namespace Contracts;

public interface IRepositoryManager 
{
    public IBookRepository Book { get; }   
    public IAuthorRepository Author { get; }
    public IPublisherRepository Publisher { get; }
}