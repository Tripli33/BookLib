using MediatR;

namespace Application.Publisher.Commands;

public sealed record DeletePublisherCommand(long Id) : IRequest<Unit>;