using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {

        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }

    }
}
