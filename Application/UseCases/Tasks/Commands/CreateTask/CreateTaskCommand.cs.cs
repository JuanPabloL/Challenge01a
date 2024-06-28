using Application.Common.Interfaces;
using Application.UseCases.Common.Handlers;
using Application.UseCases.Common.Results;
using MediatR;

namespace Application.UseCases.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : CreateTaskCommandModel , IRequest<Result<CreateTaskCommandDto>>
    {
        public class CreateTaskCommandHandler (
            IRepository<Domain.Entities.Task> taskRepository) : UseCaseHandler , IRequestHandler<CreateTaskCommand , Result<CreateTaskCommandDto>>            
        {
            public async Task<Result<CreateTaskCommandDto>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            {
                var task = new Domain.Entities.Task
                {
                    TaskId = new Guid(),
                    Name = request.Titulo,
                    Description = request.Descripcion,                   
                    Status = true,
                    DateTime = DateTime.UtcNow,
                };

                await taskRepository.AddAsync(task);

                var resultData = new CreateTaskCommandDto { Success = true };

                return Succeded(resultData);
            }
        }
    }
}
