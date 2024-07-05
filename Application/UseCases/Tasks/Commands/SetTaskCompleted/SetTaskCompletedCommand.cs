using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Tasks.Commands.SetTaskCompleted
{
    public class SetTaskCompletedCommand : SetTaskCompletedCommandModel, IRequest<Result<SetTaskCompletedCommandDto>>
    {
        public class SetTaskCompletedCommandHandler(
            IRepository<Domain.Entities.Task> taskRepository , IExternalService<LogDto> logService) : UseCaseHandler, IRequestHandler<SetTaskCompletedCommand, Result<SetTaskCompletedCommandDto>>
        {
            public async Task<Result<SetTaskCompletedCommandDto>> Handle(SetTaskCompletedCommand request, CancellationToken cancellationToken)
            {
                var task =
                    await taskRepository.GetByIdAsync(request.Id)
                    ?? throw (new ArgumentException("The transaction id does not exist"));

                task.Status = true;

                await taskRepository.UpdateAsync(task);

                LogDto log = new LogDto();

                log.Log.Id = Guid.NewGuid().ToString();
                log.Log.Description = "Task Completed Succesfully";
                log.Log.Date = DateTime.UtcNow;
                log.Log.Type = Domain.Enum.LogType.Information;

                await logService.Create(log);


                var resultData = new SetTaskCompletedCommandDto { Success = true };

                return this.Succeded(resultData);
            }
        }
            
    }
}
