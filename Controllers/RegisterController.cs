using Microsoft.AspNetCore.Mvc;
using TaskForLogix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskForLogix.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskForLogix.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationContext _context;

        public RegisterController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  IActionResult SignUpAsync()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignInAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("getuser")]
        public async  Task<IActionResult> LoginAsync([FromForm] UserRegistrationModel model)
        {
            if (model.PhoneNumber == null || model.Password == null)
            {
                return RedirectToAction("Please Enter your phoneNumber Or Password");
            }
            var user =  await _context.applicationUsers.Where(x => x.PhoneNumber == model.PhoneNumber && x.Password == model.Password).ToListAsync();

            return RedirectToAction(user);
        }

        [HttpPost]
        [ActionName("createUser")]
        public async Task<IActionResult> CreateUser([FromForm]UserRegistrationModel model)
        {
            if (model.Address == null)
            {
                 ViewBag.Error = true;
                return SignUpAsync();
            }
            var addresSTR = model.Address.ToString().ToLower();
            addresSTR += addresSTR.Replace(".", " ");
            addresSTR += addresSTR.Replace("avenue", "AVE");
            addresSTR += addresSTR.Replace("street", "ST");
            addresSTR += addresSTR.Replace("no", "N");
            addresSTR += addresSTR.Replace("#", "");
            addresSTR += addresSTR.Replace("boulevard", "BLVD");
            addresSTR += addresSTR.ToUpper();

            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FullName,
                Email = model.Email,
                Address = addresSTR,
                DateOfBirth = model.DateOfBirth,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                PasswordConfirmed = true,
                UserId = new Guid()
            };
            

            await _context.applicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

