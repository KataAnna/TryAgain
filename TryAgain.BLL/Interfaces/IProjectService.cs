using System;
using System.Collections.Generic;
using System.Text;
using TryAgain.BLL.DTO;

namespace TryAgain.BLL.Interfaces
{
    internal interface IProjectService
    {

        void MakeOrder(ProjectDTO orderDto);
        ProgrammerDTO GetWorker(int? id);
        IEnumerable<ProgrammerDTO> GetWorkers();
        void Dispose();
    }
}
