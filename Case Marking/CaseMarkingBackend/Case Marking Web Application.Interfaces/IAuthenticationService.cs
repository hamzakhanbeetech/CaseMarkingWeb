using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Application.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<IActionResult> Login(LoginModel model);
    }
}
