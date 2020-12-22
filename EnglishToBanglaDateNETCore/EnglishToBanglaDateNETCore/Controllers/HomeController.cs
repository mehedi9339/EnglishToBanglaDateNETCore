using EnglishToBanglaDateNETCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishToBanglaDateNETCore.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var hour = DateTime.Now.ToString("hh");
			var minute = DateTime.Now.ToString("mm");
			var second = DateTime.Now.ToString("ss");
			var ampm = DateTime.Now.ToString("tt");

			ViewBag.EnglishDate = DateTime.Now.ToLongDateString();
			ViewBag.EnglishTime = hour + ":" + minute + ":" + second + " " + ampm;

			ViewBag.BanglaDate = ConvertDateToBangla(DateTime.Now.ToLongDateString());
			ViewBag.BanglaTime = ConvertTimeToBangla(hour + ":" + minute + ":" + second + " " + ampm);
			return View();
		}

		private string ConvertTimeToBangla(string time)
		{
			var timeSplit = time.Split(" ");

			string banglaTime = timeSplit[0].Replace('0', '০')
											.Replace('1', '১')
											.Replace('2', '২')
											.Replace('3', '৩')
											.Replace('4', '৪')
											.Replace('5', '৫')
											.Replace('6', '৬')
											.Replace('7', '৭')
											.Replace('8', '৮')
											.Replace('9', '৯')
											.Replace(':', 'ঃ');
			return banglaTime;
		}

		private string ConvertDateToBangla(string dateTime)
		{
			string[] enWeeks = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
			string[] bnWeeks = { "রবিবার", "সোমবার", "মঙ্গলবার", "বুধবার", "বৃহস্পতিবার", "শুক্রবার", "শনিবার" };
			
			string[] enMonth = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
			string[] bnMonth = { "জানুয়ারি", "ফেব্রুয়ারি", "মার্চ", "এপ্রিল", "মে", "জুন", "জুলাই", "আগস্ট", "সেপ্টেম্বর", "অক্টোবর", "নভেম্বর", "ডিসেম্বর" };

			var dateSplit = dateTime.Split(", ");
			string weekDay = dateSplit[0];
			string monthName = dateSplit[1].Split(" ")[0];
			string date = dateSplit[1].Split(" ")[1];
			string year = dateSplit[2];

			string banglaWeekDay = bnWeeks[Array.IndexOf(enWeeks, weekDay)];
			string banglaMonth = bnMonth[Array.IndexOf(enMonth, monthName)];
			string banglaDate = date.Replace('0', '০')
									.Replace('1', '১')
									.Replace('2', '২')
									.Replace('3', '৩')
									.Replace('4', '৪')
									.Replace('5', '৫')
									.Replace('6', '৬')
									.Replace('7', '৭')
									.Replace('8', '৮')
									.Replace('9', '৯');
			string banglaYear = year.Replace('0', '০')
									.Replace('1', '১')
									.Replace('2', '২')
									.Replace('3', '৩')
									.Replace('4', '৪')
									.Replace('5', '৫')
									.Replace('6', '৬')
									.Replace('7', '৭')
									.Replace('8', '৮')
									.Replace('9', '৯');

			string bnDate = banglaWeekDay + ", " + banglaDate + " " + banglaMonth + " " + banglaYear;
			return bnDate;
		}
	}
}
