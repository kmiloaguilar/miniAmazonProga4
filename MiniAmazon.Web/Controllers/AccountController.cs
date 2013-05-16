using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MiniAmazon.Domain;
using MiniAmazon.Domain.Entities;
using MiniAmazon.Web.Models;


namespace MiniAmazon.Web.Controllers
{
    public class AccountController : BootstrapBaseController
    {
        private readonly IRepository _repository;
        private readonly IMappingEngine _mappingEngine;

        public AccountController(IRepository repository, IMappingEngine mappingEngine)
        {
            _repository = repository;
            _mappingEngine = mappingEngine;
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }

        public ActionResult SignIn(string error = null)
        {
            if (!String.IsNullOrEmpty(error))
            {
                Error(error);
            }
            return View(new AccountSignInModel());
        }


        [HttpPost]
        public ActionResult SignIn(AccountSignInModel accountSignInModel)
        {
            var account =
                _repository.First<Account>(
                    x => x.Email == accountSignInModel.Email && x.Password == accountSignInModel.Password);
            


            if (account!=null)
            {
                
                List<string> roles = account.Roles.Select(x => x.Name).ToList();
                FormsAuthentication.SetAuthCookie(accountSignInModel.Email, accountSignInModel.RememberMe);
                SetAuthenticationCookie(accountSignInModel.Email,roles);
                return RedirectToAction("Index");
            }

            Error("Email and/or password incorrect");
            return View(accountSignInModel);
        }

        public ActionResult Edit(long id)
        {
            var account = _repository.GetById<Account>(id);
            var accountInputModel = _mappingEngine.Map<Account, AccountInputModel>(account);
            return View("Create",accountInputModel);
        }

        [HttpPost]
        public ActionResult Edit(AccountInputModel accountInputModel, long id)
        {
            var account = _repository.GetById<Account>(id);
            account = _mappingEngine.Map<AccountInputModel, Account>(accountInputModel);

            Success("User {0} has been updated");
            return View("Create",accountInputModel);
        }

        [Authorize]
        public ActionResult Index()
        {
            var account = _repository.Query<Account>(x => true).ToList();
            //var accountInputModelList = account.Project().To<AccountInputModel>();
            return View(account);
            //return View(accountInputModelList);
        }

        public ActionResult Create()
        {
            return View(new AccountInputModel());
        }

        [HttpPost]
        public ActionResult Create(AccountInputModel accountInputModel)
        {
            var account = _mappingEngine.Map<AccountInputModel, Account>(accountInputModel);
            Information("This method is not implemented");
            return View(accountInputModel);
        }
    }
}