﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineJobApplication
{
    public class JobseekerAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {

                context.Result = new RedirectResult("/Error"); // Give error controller or Url name
            }
            else
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}