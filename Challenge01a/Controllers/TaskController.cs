using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Tasks.Commands.CreateTask;
using Application.UseCases.Tasks.Queries.GetTaskById;
using Application.UseCases.Tasks.Queries.GetTasks;
using Application.UseCases.Tasks.Commands.SetTaskCompleted;
using Application.UseCases.Tasks.Commands.DeleteTask;

namespace Api.Controllers;

public class TaskController : BaseController
{
    [HttpPost]
    [Route("Create")]
    [Produces(typeof(CreateTaskCommandDto))]
    [ActionName(nameof(CreateTransaction))]
    public async Task<IActionResult> CreateTransaction(CreateTaskCommandModel model)
    {
        var command = this.Mapper.Map<CreateTaskCommand>(model);
        var result = await this.Mediator.Send(command);
        return this.FromResult(result);
    }

    [HttpGet]
    [Route("GetAll")]
    [Produces(typeof(GetTasksQueryDto))]
    [ActionName(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetTasksQuery();
        var result = await this.Mediator.Send(query);
        return this.FromResult(result);
    }

    [HttpGet]
    [Route("GetById")]
    [Produces(typeof(GetTaskByIdQueryDto))]
    public async Task<IActionResult> GetById([FromQuery] GetTaskByIdQueryModel model)
    {
        var query = this.Mapper.Map<GetTaskByIdQuery>(model);
        var result = await this.Mediator.Send(query);
        return this.FromResult(result);
    }

    [HttpPut]
    [Route("SetTaskCompleted")]
    [Produces(typeof(SetTaskCompletedCommandDto))]
    public async Task<IActionResult> SetTaskCompleted( SetTaskCompletedCommandModel model )
    {
        var query = this.Mapper.Map<SetTaskCompletedCommand>(model);
        var result = await this.Mediator.Send(query);
        return this.FromResult(result);
    }

    [HttpDelete]
    [Route("DeleteTask")]
    [Produces(typeof(DeleteTaskCommandDto))]
    public async Task<IActionResult> DeleteTask(DeleteTaskCommandModel model)
    {
        var query = this.Mapper.Map<DeleteTaskCommand>(model);
        var result = await this.Mediator.Send(query);
        return this.FromResult(result);
    }
}