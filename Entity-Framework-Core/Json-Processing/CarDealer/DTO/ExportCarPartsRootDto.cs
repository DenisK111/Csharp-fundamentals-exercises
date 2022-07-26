using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class ExportCarPartsRootDto
    {
        public ExportCarDto car { get; set; }
        public IEnumerable<ExportPartDto> parts { get; set; }
    }
}
