using learn.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.service
{
    public interface IAuthenticationservice
    {
        public string Authentication_jwt(login_api login);

    }
}
