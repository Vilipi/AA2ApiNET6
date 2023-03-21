﻿namespace AA2ApiNET6._2_Domain.ServiceLibrary.Contracts.Models
{
    public class SpecialistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsRetired { get; set; }
        public decimal Rating { get; set; }
        public DateTime BirthDate { get; set; }
        public string Speciality { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
