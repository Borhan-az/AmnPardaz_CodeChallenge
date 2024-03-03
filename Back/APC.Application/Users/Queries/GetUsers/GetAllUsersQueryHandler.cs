
namespace APC.Application.Users.Queries.GetUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUserResponseDto>>
    {
        private readonly IApplicationDbContext _ctx;
        public GetAllUsersQueryHandler(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<GetAllUserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var res = await _ctx.Users.Select(s => new GetAllUserResponseDto
            {
                UserId = s.Id,
                UserName = s.UserName
            }).AsNoTracking().ToListAsync();

            return res;
        }
    }
}