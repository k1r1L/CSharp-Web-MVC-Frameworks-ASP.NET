namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Models;
    using ViewModels.Logs;

    public class LogsService : Service
    {
        public IEnumerable<LogViewModel> GetAllLogs(string user)
        {
            IEnumerable<LogViewModel> logVm;
            IEnumerable<Log> logEntities;

            if (!string.IsNullOrEmpty(user))
            {
                 logEntities = this.DbContext.Logs
                    .Where(log => log.Owner.Username == user)
                    .OrderBy(log => log.TimeLogged);
                 logVm = Mapper.Map<IEnumerable<Log>, IEnumerable<LogViewModel>>(logEntities);

                return logVm;
            }

            logEntities = this.DbContext.Logs.OrderBy(log => log.TimeLogged);
            logVm = Mapper.Map<IEnumerable<Log>, IEnumerable<LogViewModel>>(logEntities);

            return logVm;
        }

        public void DeleteAllLogs()
        {
            List<Log> allLogs = this.DbContext.Logs.ToList();
            foreach (Log log in allLogs)
            {
                this.DbContext.Entry(log).State = EntityState.Deleted;
            }

            this.DbContext.SaveChanges();
        }
    }
}
