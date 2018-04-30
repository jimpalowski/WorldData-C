
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        List<Data> allDatas = Data.GetAll();
        return View("Index", allDatas);
      }


    }
}
