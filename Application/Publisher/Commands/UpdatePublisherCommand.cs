using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Commands;

public sealed record UpdatePublisherCommand(long Id, PublisherForUpdateDto Publisher) : IRequest<Unit>;