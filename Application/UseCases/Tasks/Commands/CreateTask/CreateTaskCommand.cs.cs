using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : CreateTaskCommandModel  , IRequest<Result<CreateTaskCommandDto>>
    {
        public class CreateTaskCommandHandler (
            IRepository<Domain.Entities.Task> taskRepository , IExternalService<LogDto> logService) : UseCaseHandler , IRequestHandler<CreateTaskCommand , Result<CreateTaskCommandDto>>            
        {
            public async Task<Result<CreateTaskCommandDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            {
                var task = new Domain.Entities.Task
                {
                    TaskId = Guid.NewGuid(),
                    Name = request.Titulo,
                    Description = request.Descripcion,                   
                    Status = false,
                    DateTime = DateTime.UtcNow,
                };

                await taskRepository.AddAsync(task);

                LogDto log = new LogDto();

                log.Log.Id = Guid.NewGuid().ToString();
                log.Log.Description = "Task Created Succesfully";
                log.Log.Date = DateTime.UtcNow;
                log.Log.Type = Domain.Enum.LogType.Information;

                await logService.Create(log);

                var resultData = new CreateTaskCommandDto { Success = true };

                return Succeded(resultData);
            }
        }
    }
}
