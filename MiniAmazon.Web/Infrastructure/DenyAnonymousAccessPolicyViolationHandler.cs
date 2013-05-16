﻿using System.Web.Mvc;
using System.Web.Routing;
using FluentSecurity;

namespace MiniAmazon.Web.Infrastructure
{
    public class DenyAnonymousAccessPolicyViolationHandler : IPolicyViolationHandler
    {
        #region IPolicyViolationHandler Members

        public ActionResult Handle(PolicyViolationException exception)
        {
            return new RedirectToRouteResult("SignIn",
                                             new RouteValueDictionary
                                                 {{"error", "You have to be logged in order to view this website"}});
        }

        #endregion
    }
}