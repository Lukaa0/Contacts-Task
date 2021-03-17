using Contacts_DigitalTv.Context;
using Contacts_DigitalTv.Models;
using Contacts_DigitalTv.Services;
using Contacts_DigitalTv.Services.Interfaces;
using Contacts_DigitalTv.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.Controllers
{

    public class PersonController : Controller
    {
        private readonly IPersonService _service;
        private readonly IMapperService _mapper;
        public PersonController(IPersonService service, IMapperService mapper)
        {
            _service = service;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Person> people = await _service.GetAllAsync();
            List<ContactViewModel> models = _mapper.MapContactModels(people);

            

            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Person person = await _service.GetByIdAsync(id);
            ContactCreateEditViewModel contactViewModel = new ContactCreateEditViewModel(person, person.Phones);
            return View(contactViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContactCreateEditViewModel contactViewModel)
        {
            var person = await _service.GetByIdAsync(contactViewModel.Id);
            person.Name = contactViewModel.Name;
            person.Surename = contactViewModel.Surename;
            person.AddressLine = contactViewModel.AddressLine;
            person.Birthdate = contactViewModel.Birthdate;
            person.City= contactViewModel.City;


            for (int i = 0; i < person.Phones.Count; i++)
            {
                person.Phones.ToList()[i].Number = contactViewModel.Phones[i].Number;
                person.Phones.ToList()[i].Type = contactViewModel.Phones[i].Type;

            }
            if (contactViewModel.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    contactViewModel.Image.CopyTo(ms);
                    person.Image = ms.ToArray();
                }
            }
            await _service.UpdateAsync(person);

            return RedirectToAction("index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            Person person = await _service.GetByIdAsync(id);
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Person person)
        {


            await _service.DeleteAsync(person);

            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Create()
        {

            ContactViewModel contactCreateViewModel = new ContactViewModel();
            contactCreateViewModel.Phones.Add(new PhonesViewModel());
            return View(contactCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ContactCreateEditViewModel contactCreateViewModel)
        {
            Person person = _mapper.MapPerson(contactCreateViewModel);
            if (contactCreateViewModel.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    contactCreateViewModel.Image.CopyTo(ms);
                    person.Image = ms.ToArray();
                }
            }
            await _service.CreateAsync(person);

            return RedirectToAction("index");
        }
        public async Task<IActionResult> AddToFavorite(int id)
        {
            Person person = await _service.GetByIdAsync(id);
            person.IsFavorite = !person.IsFavorite;
            await _service.UpdateAsync(person);
            return RedirectToAction("index");


        }
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var people = await _service.GetFavorites();
            List<ContactViewModel> models = _mapper.MapContactModels(people);
            return View("Index", models);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }


}
