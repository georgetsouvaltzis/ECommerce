using System;

namespace ECommerce.Domain.DomainHelpers
{
    public class NoNullOrEmpty
    {
        public NoNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidOperationException(nameof(value) + " should not be null or empty!");
            Value = value;
        }

        public string Value { get;  }
        
        public static implicit operator NoNullOrEmpty(string val) => new NoNullOrEmpty(val);
        public static implicit operator string(NoNullOrEmpty val) => val.Value;
    }
}
