using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using MediatR;

namespace Application.UseCases.Tasks.Queries.GetTaskById
{
    public class GetTaskByIdQuery : GetTaskByIdQueryModel, IRequest<Result<GetTaskByIdQueryDto>>
    {
        public class GetTaskByIdQueryHandler(
            IRepository<Domain.Entities.Task> taskRepository) : UseCaseHandler, IRequestHandler<GetTaskByIdQuery, Result<GetTaskByIdQueryDto>>
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

                return this.Succeded(resultData);
            }
        }
    }
}