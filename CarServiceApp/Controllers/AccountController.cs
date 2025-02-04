using Microsoft.AspNetCore.Mvc;
using CarServiceApp.Data;
using CarServiceApp.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CarServiceApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string SecretKey = "YourSuperSecretKeyForTokenGeneration";

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Register form
        public IActionResult Register()
        {
            return View("~/Views/Home/Registry.cshtml"); 
        }

        // POST: Process registration
        [HttpPost]
        public IActionResult Register(string FirstName, string LastName, string Email, string Password)
        {
            
            if (_context.Users.Any(u => u.Email == Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View("~/Views/Home/Registry.cshtml"); 
            }

           
            var passwordHash = HashPassword(Password);

           
            var user = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();
      
            var token = GenerateToken(user);

            //Save token in Cookie
            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.Now.AddDays(1)
            });
            return RedirectToAction("Account", "Account"); 
        }

        // GET: Login form
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml"); 
        }

        // POST: Process login
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            
            var user = _context.Users.FirstOrDefault(u => u.Email == Email);
            if (user == null || !VerifyPassword(Password, user.PasswordHash))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View("~/Views/Home/Login.cshtml"); 
            }

           
            var token = GenerateToken(user);

            //Save token in Cookie
            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.Now.AddDays(1)
            });

            return RedirectToAction("Account", "Account"); 
        }

        // GET: Account page
        public IActionResult Account()
        {
            //Check token in cookie
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(SecretKey);

                try
                {
                    var validations = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    var claimsPrincipal = handler.ValidateToken(token, validations, out _);

                    
                    ViewBag.User = new
                    {
                        Name = claimsPrincipal.Identity?.Name,
                        Email = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value
                    };

                    return View("~/Views/Home/Account.cshtml"); 
                }
                catch
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            return RedirectToAction("Login", "Account");
        }

        // POST: Logout
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Login", "Account");
        }

        // Helper method: Hash password
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        // Helper method: Verify password
        private bool VerifyPassword(string password, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                var hashString = Convert.ToBase64String(hash);
                return hashString == storedHash;
            }
        }

        // Helper method: Generate token
        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "CarServiceApp",
                audience: "CarServiceApp",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
