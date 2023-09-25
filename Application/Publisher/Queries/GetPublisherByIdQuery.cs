using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Queries;

public sealed record GetPublisherByIdQuery(long Id) : IRequest<PublisherDto>;