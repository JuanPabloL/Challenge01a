using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQuery : GetTaskByIdQueryModel, IRequest<Result<GetTaskByIdQueryDto>>
    {
        public class GetTaskByIdQueryHandler(
            IRepository<Domain.Entities.Task> taskRepository , IExternalService<LogDto> logService) : UseCaseHandler, IRequestHandler<GetTaskByIdQuery, Result<GetTaskByIdQueryDto>>
        {
            public async Task<Result<GetTaskByIdQueryDto>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
            {
                var task = await taskRepository.GetByIdAsync(request.Id) ?? throw new ArgumentNullException("The transaction id does not exist");

                var resultData = new GetTaskByIdQueryDto()
                {
                     Id = task.TaskId,
                     Titulo = task.Name,
                     Descripcion = task.Description,                     
                     DateTime = task.DateTime,
                     Estado = task.Status
                };

                LogDto log = new LogDto();

                log.Log.Id = Guid.NewGuid().ToString();
                log.Log.Description = "Task Queryed By Id Succesfully";
                log.Log.Date = DateTime.UtcNow;
                log.Log.Type = Domain.Enum.LogType.Information;

                await logService.Create(log);

                return this.Succeded(resultData);
            }
        }
    }
}