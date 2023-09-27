using MediatR;
using Shared.DataTransferObjects.CustomerBook;

namespace Application.CustomerBook.Commands;

public record AddCustomerBookCommand(long CustomerId, CustomerBookDto Book) : IRequest<Unit>;