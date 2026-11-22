using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Zadacha1zhd.Models;
using System.Security.Cryptography.X509Certificates;

namespace Zadacha1zhd.Controllers
{
    public class ProfileController : Controller
    {
        public static List<BookingModel> testBooking = new()
        {
            new BookingModel
            {
                Id = 1,
                StartRent = DateTime.Now,
                EndRent = DateTime.Now.AddDays(2),
                TotalPrice = 1000,
                Status = BookingStatus.Confirmed,
                Product = new RentProductModel { Title = "Велосипед горный", URLImage = "/Images/Велосипед.png" }
            },
            new BookingModel
            {
                Id = 2,
                StartRent = DateTime.Now,
                EndRent = DateTime.Now.AddDays(2),
                TotalPrice = 1000,
                Status = BookingStatus.Confirmed,
                Product = new RentProductModel { Title = "Велосипед горный", URLImage = "/Images/Велосипед.png" }
            },
            new BookingModel
            {
                Id = 3,
                StartRent = DateTime.Now,
                EndRent = DateTime.Now.AddDays(2),
                TotalPrice = 1000,
                Status = BookingStatus.Confirmed,
                Product = new RentProductModel { Title = "Велосипед горный", URLImage = "/Images/Велосипед.png" }
            },
            new BookingModel
            {
                Id = 4,
                StartRent = DateTime.Now,
                EndRent = DateTime.Now.AddDays(2),
                TotalPrice = 1000,
                Status = BookingStatus.Confirmed,
                Product = new RentProductModel { Title = "Велосипед горный", URLImage = "/Images/Велосипед.png" }
            },
            new BookingModel
            {
                Id = 5,
                StartRent = DateTime.Now,
                EndRent = DateTime.Now.AddDays(2),
                TotalPrice = 1000,
                Status = BookingStatus.Confirmed,
                Product = new RentProductModel { Title = "Велосипед горный", URLImage = "/Images/Велосипед.png" }
            },
            new BookingModel
            {
                Id = 6,
                StartRent = DateTime.Now,
                EndRent = DateTime.Now.AddDays(2),
                TotalPrice = 1000,
                Status = BookingStatus.Confirmed,
                Product = new RentProductModel { Title = "Велосипед горный", URLImage = "/Images/Велосипед.png" }
            },
            new BookingModel
            {
                Id = 7,
                StartRent = DateTime.Now.AddDays(10),
                EndRent = DateTime.Now.AddDays(12),
                TotalPrice = 2000,
                Status = BookingStatus.Pending,
                Product = new RentProductModel { Title = "Палатка", URLImage = "/Images/Палатка.png" }
            },
            new BookingModel
            {
                Id = 8,
                StartRent = DateTime.Now.AddDays(-10),
                EndRent = DateTime.Now.AddDays(-8),
                TotalPrice = 1500,
                Status = BookingStatus.Returned,
                Product = new RentProductModel { Title = "Самокат электрический", URLImage = "/Images/Самокат.png" }
            }
        };
        [HttpGet]
        public IActionResult Profile()
        {
            var testUser = new AuthenticationModel
            {
                Login = "Ivan2026",
                FirstName = "Иван",
                LastName = "Иванов",
                Patronymic = "Иванович",
                Email = "ivan@mail.ru",
                PhoneNumber = "+79067543456",
                Bookings = testBooking
            };

            return View("~/Views/WindowProfile/profile.cshtml", testUser);
        }

        [HttpPost]
        public IActionResult CancelBooking(int id)
        {
            var booking = testBooking.FirstOrDefault(b => b.Id == id);
            if (booking != null)
            {
                if (booking.Status == BookingStatus.Confirmed)
                {
                    booking.Status = BookingStatus.CancelledConfirmed;
                }
                else if (booking.Status == BookingStatus.Pending)
                {
                    booking.Status = BookingStatus.Cancelled;
                }
            }

            return RedirectToAction("Profile");
        }
    }
}