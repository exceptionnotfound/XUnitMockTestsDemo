using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LeagueID { get; set; }
        public DateTime FoundingDate { get; set; }
    }
}
