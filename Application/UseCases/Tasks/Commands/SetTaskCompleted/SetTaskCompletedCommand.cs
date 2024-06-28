using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using MediatR;

namespace Application.UseCases.Tasks.Commands.SetTaskCompleted
{
    public class SetTaskCompletedCommand : SetTaskCompletedCommandModel, IRequest<Result<SetTaskCompletedCommandDto>>
    {
        public class SetTaskCompletedCommandHandler(
            IRepository<Domain.Entities.Task> taskRepository) : UseCaseHandler, IRequestHandler<SetTaskCompletedCommand, Result<SetTaskCompletedCommandDto>>
        {
            public async Task<Result<SetTaskCompletedCommandDto>> Handle(SetTaskCompletedCommand request, CancellationToken cancellationToken)
            {
                var task =
                    await taskRepository.GetByIdAsync(request.Id)
                    ?? throw (new ArgumentException("The transaction id does not exist"));

                task.Status = true;

                await taskRepository.UpdateAsync(task);

                var resultData = new SetTaskCompletedCommandDto { Success = true };

                return this.Succeded(resultData);
            }
        }
            
    }
}
