using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Domain.ViewModels
{
    public class TokenApiViewModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
