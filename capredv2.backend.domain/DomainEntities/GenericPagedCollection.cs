using System;
using System.Collections.Generic;

namespace capredv2.backend.domain.DomainEntities
{
    public class GenericPagedCollection<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public double Count { get; set; }
        // ReSharper disable once RedundantCast (force cast to Double to prevent from changing Count to int and calculating the Total PAges incorrectly)
        public int TotalPages => (int)Math.Ceiling((double)Count / PageSize);
        public IEnumerable<T> Data { get; set; }
    }
}