﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
