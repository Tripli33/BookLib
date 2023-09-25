using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Queries;

public sealed record GetAllPublishersQuery : IRequest<IEnumerable<PublisherDto>>;
