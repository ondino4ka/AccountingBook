﻿using AccountingBookBL.Providers.Interfaces;
using AccountingBookBL.Services.Interfaces;
using AccountingBookCommon.Enums;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace AccountingBookBL.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserProvider _userProvider;
        private readonly IHashService _hashService;
        public LoginService(IUserProvider userProvider, IHashService hashService)
        {
            if (userProvider == null || hashService == null)
            {
                throw new ArgumentNullException("userProvider or hashService is null");
            }
            _userProvider = userProvider;
            _hashService = hashService;
        }
        public LoginResult Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return LoginResult.EmptyCredentials;
            }

            if (_userProvider.IsValidUser(userName, _hashService.GetHash(password)))
            {
                var user = _userProvider.GetUserByName(userName);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(2, user.Name, DateTime.Now, DateTime.Now.AddHours(1), false, userData);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                HttpContext.Current.Response.Cookies.Add(authCookie);
                return LoginResult.NoError;
            }
            return LoginResult.InvalidCredentials;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
