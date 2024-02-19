using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class CommentEntity
{
    public int Id { get; set; } = default;
    public int PostId { get; set; } = default;
    public string Name { get; set; } = default;
    public string Email { get; set; } = default;
    public string Body { get; set; } = default;
}
