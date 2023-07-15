using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Mappings;
using MyMovies.Servises.Interfaces;
using System;
using System.Linq;

namespace MyMovies.Controllers
{
    public class UsersController : Controller
    {
        private  IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [Authorize]
        public IActionResult Details() 
        {
            try
            {
                var userId = User.FindFirst("Id").Value;
                var user = _usersService.GetDetails(userId);

                if (user == null)
                {
                    RedirectToAction("ErrorNotFound", "Info");
                }
                return View(user.ToDetailsModel());
            }
            catch (Exception)
            {

                return RedirectToAction("InternalError", "Info");
            }
           
        }

        [Authorize (Policy ="IsAdmin")]
        public IActionResult ManageUsers(string successMessage, string errorMessage)
        {
            try
            {
                ViewBag.ErrorMessage = errorMessage;
                ViewBag.SuccessMessage = successMessage;
                var id = int.Parse(User.FindFirst("Id").Value);
                var users = _usersService.GetAll();
                var viewModel = users.Where(x => x.Id != id).Select(x => x.ToManageUsersModel()).ToList();

                return View(viewModel);
            }
            catch (Exception)
            {

                return RedirectToAction("InternalError", "Info");
            }
           
        }


        [Authorize(Policy = "IsAdmin")]
        public IActionResult ToggleAdminRole(int id) 
        {
            try
            {
                var response = _usersService.ToggleAdminRole(id);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageUsers", new { SuccessMessage = "User role updated successfuly" });
                }
                else
                {
                    return RedirectToAction("ManageUsers", new { ErrorMessage = response.Message });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
           
            
        }
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _usersService.Delete(id);
                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageUsers", new { SuccessMessage = "User was deleted successfuly" });
                }
                else
                {
                    return RedirectToAction("ManageUsers", new { ErrorMessage = response.Message });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
            
        }

    }
} 
