﻿using System;

namespace BlogProject.Models.ORM
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
