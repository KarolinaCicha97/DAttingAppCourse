using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage,
            int itempsPerPage,int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage,itempsPerPage,totalItems,totalPages);
            var option = new JsonSerializerOptions{
                PropertyNamingPolicy=JsonNamingPolicy.CamelCase
            };
            response.Headers.Add("Pagination",JsonSerializer.Serialize(paginationHeader,option));
            response.Headers.Add("Access-Control-Expose-Headers","Pagination");

        }
    }
}