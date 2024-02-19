using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class RateEntity
{
    public int Id { get; set; } = default;
    public int MovieId { get; set; } = default;
    public int Rate { get; set; } = default;
}
