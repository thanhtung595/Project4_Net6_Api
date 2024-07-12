using Lib_Models.Model_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Models.Model_Get
{
    public class CartGetAll : BaseEntity
    {
        public string? nameProduct { get; set; }
        public int count { get; set; }
        public int idProduct { get; set; }
        public string? imgProduct { get; set; }
        public float priceProduct { get; set; }
        public float priceTotal { get; set; }
    }
}
