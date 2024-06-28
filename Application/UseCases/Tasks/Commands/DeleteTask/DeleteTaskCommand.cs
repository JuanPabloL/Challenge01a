using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using MediatR;

namespace Application.UseCases.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : DeleteTaskCommandModel , IRequest<Result<DeleteTaskCommandDto>>
    {
        public class DeleteTaskCommandHandler(
            IRepository<Domain.Entities.Task> taskRepository) : UseCaseHandler, IRequestHandler<DeleteTaskCommand, Result<DeleteTaskCommandDto>>         
        {
            public async Task<Result<DeleteTaskCommandDto>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await taskRepository.GetByIdAsync(request.Id) ?? throw (new ArgumentException("The transaction id does not exist"));

                await taskRepository.RemoveAsync(task);

                var resultData = new DeleteTaskCommandDto { Success = true };

                return this.Succeded(resultData);

            }
        }
    }
}