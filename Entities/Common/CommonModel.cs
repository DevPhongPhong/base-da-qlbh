using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Common
{
    public class CommonModel
    {
    }
    public class PaginationModel<T>
    {
        public PaginationModel()
        {
            Pagination = new Pagination();
        }
        public T Data { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Offset { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
    }

    public class PaginationModelExtent<T, TAdditionalData>
    {
        public PaginationModelExtent()
        {
            Pagination = new PaginationExtent<TAdditionalData>();
        }
        public T Data { get; set; }
        public PaginationExtent<TAdditionalData> Pagination { get; set; }
    }

    public class PaginationExtent<TAdditionalData>
    {
        public int Offset { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public TAdditionalData AdditionalData { get; set; }
    }
}
