using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Export
{
    public interface IExportService
    {
        IEnumerable<ExportViewModel> GetExportViewModels();
    }
}
