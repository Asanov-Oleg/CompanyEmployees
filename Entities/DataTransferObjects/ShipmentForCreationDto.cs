﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ShipmentForCreationDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public Guid Time { get; set; }
    }
}
