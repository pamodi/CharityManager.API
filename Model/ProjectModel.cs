﻿using CharityManager.API.Entity;

namespace CharityManager.API.Model
{
    public class ProjectModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Category { get; set; }
        public string? Coordinator { get; set; }
    }
}
