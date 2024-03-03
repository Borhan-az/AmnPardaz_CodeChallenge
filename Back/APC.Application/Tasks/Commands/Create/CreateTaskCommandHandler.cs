namespace APC.Application.Tasks.Commands.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponseDto>
    {
        private readonly IApplicationDbContext _ctx;
        public CreateTaskCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<CreateTaskResponseDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            /// TODO : should be add mapster  
            var task = new Domain.Entities.TodoLists.Todo
            {
                Id = Guid.NewGuid(),
                Title = request.Task.Title,
                Description = request.Task.Description,
                UserId = request.UserId
            };
            await _ctx.Todos.AddAsync(task);

            if (await _ctx.SaveChangesAsync() > 0)
                return new CreateTaskResponseDto(task.Id);

            throw new Exception("Internal Error");

        }
    }
}