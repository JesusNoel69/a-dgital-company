using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace a_digital_company.Application.Exceptions
{
    public class NotFoundException(string name, object key) : Exception($"{name} ({key}) was not found")
    {
    }
}