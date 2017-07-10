using HostelBooking.Api.Security;
using HostelBooking.Domain.AppService;
using HostelBooking.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace HostelBooking.Api.Controllers
{
    public class AccountController : BaseController
    {
        private User _user;
        private readonly IGuestAppService _app;
        private readonly TokenOptions _tokenOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public AccountController(IOptions<TokenOptions> jwtOptions, IGuestAppService app)
        {
            _app = app;
            _tokenOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_tokenOptions);

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/authenticate")]
        public async Task<IActionResult> Post([FromForm] User user)
        {
            var identity = await GetClaims(user);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("HostelBooking")
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims.AsEnumerable(),
                notBefore: _tokenOptions.NotBefore,
                expires: _tokenOptions.Expiration,
                signingCredentials: _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                user = new
                {
                    email = _user.Email
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/register")]
        public async Task<IActionResult> Register([FromBody]Guest guest)
        {
            _app.Save(guest);
            return await Response("", new[] { "Guest Registered." });
        }

        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maior que zero", nameof(TokenOptions.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private Task<ClaimsIdentity> GetClaims(User user)
        {
            var guest = _app.GetByEmail(user.Email);

            if (guest == null)
                return Task.FromResult<ClaimsIdentity>(null);

            if (!guest.User.Authenticate(user.Email, user.Password))
                return Task.FromResult<ClaimsIdentity>(null);

            _user = user;

            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(user.Email, "Token"),
                new[] {
                    new Claim("HostelBooking", "User")
                }));
        }
    }
}
