namespace APC.Application.Auth.Commands.LoginUser
{
    public class LoginUserResponseDto
    {
        public string Token { get; set; }
        public LoginUserResponseDto(string jwtToken)
        {
            Token = jwtToken;
        }
    }
}