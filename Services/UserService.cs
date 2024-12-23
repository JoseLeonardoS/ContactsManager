
using ContactsManager.Data;
using ContactsManager.Models;
using ContactsManager.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ContactsManager.Services
{
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<UserModel>> ListUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<string> Login(LoginDto login)
        {
            try
            {
                var usr = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
                if (usr == null) return "User not found";

                bool verify = BCrypt.Net.BCrypt.Verify(login.Password, usr.Password);
                if (!verify) return "Invalid password";

                var jwtSettings = _configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("Email", login.Email)
                };

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(double.Parse("60")),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<string> Regiter(UserModel user)
        {
            try
            {
                var usr = new UserModel
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                    Phone = user.Phone
                };

                _context.Users.Add(usr);
                await _context.SaveChangesAsync();

                return "Usuário criado com sucesso";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
