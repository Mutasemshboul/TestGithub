using learn.core.DTO;
using learn.core.Repoisitory;
using learn.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class emp_api_service : Iemp_service
    {
        private readonly Iemp_apirepositiory iemp_;
        public emp_api_service(Iemp_apirepositiory iemp_)
        {
            this.iemp_ = iemp_;
        }
        public List<emp_dto> get()
        {
            return iemp_.getfnamelnamesalary();
        }

        public List<emp_dto> getfnamedate(emp_Date emp)
        {
            return iemp_.getfnamedate(emp);
        }

        public List<emp_dto> getfnamelnamedate(emp_Date emp)
        {
            return iemp_.getfnamelnamedate(emp);
        }
    }
}
