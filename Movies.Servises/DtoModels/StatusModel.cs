using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Servises.DtoModels
{
    public class StatusModel
    {
        public StatusModel()
        {
            IsSuccessful = true;
        }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
