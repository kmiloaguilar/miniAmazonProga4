using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniAmazon.Domain;
using MiniAmazon.Domain.Entities;

namespace MiniAmazon.Web.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        private readonly IRepository _repository;


        public AccountController(IRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Account/SignIn

        public ActionResult SignIn()
        {
            return View();
        }

        //
        // GET: /Account/Index

        public ActionResult Index()
        {
            var accounts = _repository.Query<Account>(x=>x.Email=="camilo.aguilar@me.com").ToList();

            var accountInputModels = accounts.Select(account => new AccountInputModel
                {
                    Email = account.Email, Id = account.Id, Name = account.Name
                }).ToList();

            return View(accountInputModels);
        }

        public ActionResult Details(long id)
        {
            var account = _repository.GetById<Account>(id);
            var accountInputModel = new AccountInputModel
                {
                    Email = account.Email,
                    Id = account.Id,
                    Name = account.Name
                };

            return View(accountInputModel);
        }

    }

    public class AccountInputModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
