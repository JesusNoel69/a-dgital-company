using Microsoft.AspNetCore.Mvc;

namespace a-digital-company.API.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();        
    }
}