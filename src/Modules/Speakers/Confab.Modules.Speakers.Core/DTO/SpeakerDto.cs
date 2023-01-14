﻿using Confab.Modules.Speakers.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Core.DTO
{
    internal class SpeakerDto
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Bio { get; set; }

        public string AvatarUrl { get; set; }

        internal Speaker AsEntity()
        {
            throw new NotImplementedException();
        }
    }
}