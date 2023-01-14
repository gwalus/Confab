using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Core.Entities
{
    internal class Speaker
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
    }
}