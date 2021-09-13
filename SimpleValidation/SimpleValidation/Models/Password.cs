using System.Collections.Generic;

namespace SimpleValidation.Models
{
    public class Password
    {
        public int Length { get; set; }
        
        public List<char> SpecialSymbols { get; set; }
    }
}