using System;

namespace ECommerce.Domain.DomainHelpers
{
    public class MustBe<T> where T: class
    {
        public MustBe(T value)
        {
            if (value == null) throw new InvalidOperationException(nameof(value) + " can not be null");
            Value = value;    
        }
        public T Value { get; }
        
    }
}
