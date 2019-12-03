using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TeamID { get; set; }
    }
}
