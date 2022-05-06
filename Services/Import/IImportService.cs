using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Import
{
    public interface IImportService
    {
        bool AddImport(ImportViewModel model);
        IEnumerable<ImportViewModel> GetImportViewModels();
    }
}
