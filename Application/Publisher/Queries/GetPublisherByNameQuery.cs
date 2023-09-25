using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Queries;

public sealed record GetPublisherByNameQuery(string PublisherName) : IRequest<PublisherDto>;