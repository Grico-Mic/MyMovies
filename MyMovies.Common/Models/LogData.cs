﻿using System;

namespace MyMovies.Common.Models
{
    public class LogData
    {
        public LogType Type { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
