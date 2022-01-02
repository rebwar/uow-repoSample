using System;

namespace uow_repoSample.Models
{
    public class Student
    {
        public Guid Id { get; set; }        

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }
    }
}