namespace APC.Application.Tasks.Commands.Create
{

    public class CreateTaskCommand : IRequest<CreateTaskResponseDto>
    {
        public Guid UserId { get; set; }
        public CreateTaskRequestDto Task { get; set; }
        public CreateTaskCommand(Guid userId, CreateTaskRequestDto task)
        {
            UserId = userId;
            Task = task;
        }
    }
}