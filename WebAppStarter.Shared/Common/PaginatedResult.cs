﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppStarter.Shared.Common
{
    public class PaginatedResult<T>
    {
        public PaginatedResult() { }
        public PaginatedResult(IEnumerable<T> items, int total, int pageIndex, int pageSize)
        {
            Items = items;
            TotalItems = total;
            CurrentPage = pageIndex;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
        }

        public int CurrentPage { get; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
    }
}