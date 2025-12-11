// using System.Security.Cryptography;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.IdentityModel.Tokens;
//
// namespace BreadBoard.Infra.JWTBearer.Extensions;
//
// public static class JWTExtensions
// {
//     public static WebApplication UseJWTBearer(this WebApplication builder)
//     {
//         var config = builder.Configuration.GetSection("Jwt");
//         
//         var rsa = RSA.Create();
//         //qq eh isso aqui?
//         rsa.ImportFromPem(File.ReadAllText("keys/private.pem"));
//         
//         var key = new RsaSecurityKey(rsa) { KeyId = "kid-1" };
//
//         builder.Services.AddAuthentication(options =>
//             {
//                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//             })
//             .AddJwtBearer(options =>
//             {
//                 // options.TokenValidationParameters = new TokenValidationParameters
//                 // {
//                 //     ValidateIssuer = true,
//                 //     ValidateAudience = true,
//                 //     ValidateLifetime = true,
//                 //     ValidateIssuerSigningKey = true,
//                 //     ValidIssuer = builder.Configuration["Jwt:Issuer"],
//                 //     ValidAudience = builder.Configuration["Jwt:Audience"],
//                 //     IssuerSigningKey = new SymmetricSecurityKey(
//                 //         Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//                 // };
//             });
//     }
//
// }