using MediatR;
using Shared.DataTransferObjects.Publisher;

namespace Application.Publisher.Commands;

public sealed record AddPublisherCommand(PublisherForAddDto Publisher) : IRequest<Unit>;