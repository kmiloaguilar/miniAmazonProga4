using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MiniAmazon.Domain;
using MiniAmazon.Domain.Entities;
using MiniAmazon.Web.Models;
using AutoMapper.QueryableExtensions;

namespace MiniAmazon.Web.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        private readonly IMappingEngine _mappingEngine;
        private readonly IRepository _repository;


        public AccountController(IRepository repository, IMappingEngine mappingEngine)
        {
            _repository = repository;
            _mappingEngine = mappingEngine;
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
            var accounts = _repository.Query<Account>(x => x.Email == "camilo.aguilar@me.com");

            List<AccountInputModel> accountInputModels = accounts.Project().To<AccountInputModel>().ToList();

            return View(accountInputModels);
        }

        //
        // GET: /Account/Details/{id}

        public ActionResult Details(long id)
        {
            var account = _repository.GetById<Account>(id);

            AccountInputModel accountInputModel = _mappingEngine.Map<Account, AccountInputModel>(account);

            return View(accountInputModel);
        }
    }
}