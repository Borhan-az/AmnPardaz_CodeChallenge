namespace APC.Application.Auth.Commands.RegisterUser
{
    public record RegisterUserCommand : IRequest<Unit>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}