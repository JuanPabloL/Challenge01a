using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Tasks.Queries.GetTasks
{
    public class GetTasksQuery : IRequest<Result<GetTasksQueryDto>>
    {
        public class GetTasksQueryHandler(
            IConfiguration configuration,
            IRepository<Domain.Entities.Task> taskRepository , IExternalService<LogDto> logService) : UseCaseHandler, IRequestHandler<GetTasksQuery, Result<GetTasksQueryDto>>
        {
            public async Task<Result<GetTasksQueryDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
            {
                var tasks = await taskRepository.GetAllAsync();

                var tasksDto = tasks
                    .Select(x => new GetTasksQueryValueDto()
                    {
                         Id = x.TaskId,
                         Titulo = x.Name,
                         Descripcion = x.Description,                         
                         DateTime = x.DateTime,
                         Estado = x.Status                         
                    });

                var resultData = new GetTasksQueryDto()
                {
                    Tasks = tasksDto
                };

                LogDto log = new LogDto();

                log.Log.Id = Guid.NewGuid().ToString();
                log.Log.Description = "Tasks Queryed Succesfully";
                log.Log.Date = DateTime.UtcNow;
                log.Log.Type = Domain.Enum.LogType.Information;

                await logService.Create(log);


                return this.Succeded(resultData);
            }
        }
    }
}
