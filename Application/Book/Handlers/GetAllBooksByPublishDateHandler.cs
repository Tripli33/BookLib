using Application.Book.Queries;
using Contracts;
using MediatR;
using Shared.DataTransferObjects.Book;

namespace Application.Book.Handlers
{
    public class GetAllBooksByPublishDateHandler : IRequestHandler<GetAllBooksByPublishDateQuery, IEnumerable<ExtendBookDto>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllBooksByPublishDateHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<ExtendBookDto>> Handle(GetAllBooksByPublishDateQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryManager.Book.GetAllBooksByPublishDate(request.publishDate);
        }
    }
}