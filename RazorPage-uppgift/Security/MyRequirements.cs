using RazorPage_uppgift.Data;
using RazorPage_uppgift.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage_uppgift.Security
{
    public class MyRequirements : IAuthorizationRequirement
    {
    }
}
