namespace Application.UseCases.Tasks.Queries.GetTasks
{
    public class GetTasksQueryValueDto
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;        

        public DateTime DateTime { get; set; }

        public bool Estado { get; set; }
    }
}
