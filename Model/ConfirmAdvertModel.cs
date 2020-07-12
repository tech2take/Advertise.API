using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Advertise.API.Model
{
    public class ConfirmAdvertModel
    {
        public string Id { get; set; }
        public AdvertStatus Status { get; set; }

    }
}
