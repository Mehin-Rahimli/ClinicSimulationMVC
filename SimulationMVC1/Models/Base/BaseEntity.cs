﻿namespace SimulationMVC1.Models;
 
   public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

}

