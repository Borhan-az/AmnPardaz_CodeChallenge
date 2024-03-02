namespace APC.Application.Tasks.Commands.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskResponseDto>
    {
        private readonly IApplicationDbContext _ctx;
        public CreateTaskCommandHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public Task<CreateTaskResponseDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}