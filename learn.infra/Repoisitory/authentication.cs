using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class authentication : IAuthentication
    {
        private readonly IDBContext dBContext;
        public authentication(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public login_api auth(login_api login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("email1", login.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<login_api> result = dBContext.dBConnection.Query<login_api>("loginapi_package.Auth", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
