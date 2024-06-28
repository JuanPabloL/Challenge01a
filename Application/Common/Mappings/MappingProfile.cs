using Application.UseCases.Tasks.Commands.CreateTask;
using Application.UseCases.Tasks.Commands.DeleteTask;
using Application.UseCases.Tasks.Commands.SetTaskCompleted;
using Application.UseCases.Tasks.Queries.GetTaskById;
using AutoMapper;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            this.CreateMap<CreateTaskCommandModel, CreateTaskCommand>();
            this.CreateMap<GetTaskByIdQueryModel, GetTaskByIdQuery>();
            this.CreateMap< SetTaskCompletedCommandModel , SetTaskCompletedCommand>();
            this.CreateMap<DeleteTaskCommandModel , DeleteTaskCommand>();
        }
    }
}
