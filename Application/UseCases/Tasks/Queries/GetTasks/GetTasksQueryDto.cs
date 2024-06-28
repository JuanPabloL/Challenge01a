namespace Application.UseCases.Tasks.Queries.GetTasks
{
    public class GetTasksQueryDto
    {
        public IEnumerable<GetTasksQueryValueDto> Tasks { get; set; } = new List<GetTasksQueryValueDto>();
    }
}
