﻿namespace Application.Web.Areas.Administration.Controllers.Base
{
    using System.Globalization;
    using System.Web.Mvc;

    using Application.Common;
    using Application.Data.Contracts;
    using Application.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class AdminBaseController : BaseController
    {
        public AdminBaseController(IDataProvider provider)
            : base(provider)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
    }
}