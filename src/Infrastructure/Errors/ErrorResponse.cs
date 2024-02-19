using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Errors;

public class ErrorResponse
{
    public string Message { get; set; } = string.Empty;

    public static ErrorResponse Create(string message)
    {
        return new ErrorResponse
        {
            Message = message
        };
    }
}

