using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TryAgain.BLL.DTO;
using TryAgain.BLL.Interfaces;
using TryAgain.DAL.Interfaces;
using TryAgain.DAL.Entities;


namespace TryAgain.BLL.Services
{
    class OrderServices: IProjectService
    {
        IUnitOfWork Database { get; set; }

        public OrderServices(IUnitOfWork uow)
        {
            Database = uow;
        }
        [HttpPost]
        [ActionName("Make Order")]
        public void MakeOrderAction(ProjectDTO orderDto)
        {
            Programmer worker = Database.Programmers.Get(orderDto.Id);

            // валидация
            if (worker == null)
                throw new ValidationException("This worker doesn't exist");
            
            Project project = new Project
            {
                Name= orderDto.Name,
                ProgrammerId = worker.Id,
                
            };
            Database.Projects.Create(project);
            Database.Save();
        }

        public IEnumerable<ProgrammerDTO> GetWorker()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Programmer, ProgrammerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Programmer>, List<ProgrammerDTO>>(Database.Programmers.GetAll());
        }

        [HttpPost]
        [ActionName("Get Worker")]
        public ProgrammerDTO GetWorkerAction(int? id)
        {
            if (id == null)
                throw new ValidationException("Worker doesn't exist");
            var worker = Database.Programmers.Get(id.Value);
            if (worker == null)
                throw new ValidationException("Worker doesn't found");

            return new ProgrammerDTO {  Id = worker.Id, FirstName = worker.FirstName, LastName = worker.LastName, Email = worker.Email };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
        [HttpPost]
        public void MakeOrder(ProjectDTO orderDto)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public ProgrammerDTO GetWorker(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProgrammerDTO> GetWorkers()
        {
            throw new NotImplementedException();
        }
    }
}
