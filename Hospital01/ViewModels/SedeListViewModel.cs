using cloudscribe.Pagination.Models;
using Hospital01.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital01.ViewModels
{
    public class SedeListViewModel
    {
        public SedeListViewModel() {
            SedeList = new PagedResult<SedeDto>();
        }

        public string Query { get; set; } = string.Empty;
        public PagedResult<SedeDto> SedeList { get; set; } = null;
    }
}
