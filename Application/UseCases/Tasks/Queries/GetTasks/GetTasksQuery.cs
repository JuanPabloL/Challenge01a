using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using MediatR;

namespace Application.UseCases.Tasks.Queries.GetTasks
{
    public class GetTasksQuery : IRequest<Result<GetTasksQueryDto>>
    {
        public class GetTasksQueryHandler(
            IConfiguration configuration,
            IRepository<Domain.Entities.Task> taskRepository) : UseCaseHandler, IRequestHandler<GetTasksQuery, Result<GetTasksQueryDto>>
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

                return this.Succeded(resultData);
            }
        }
    }
}
