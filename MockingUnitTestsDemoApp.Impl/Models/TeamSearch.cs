using MockingUnitTestsDemoApp.Impl.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Models
{
    public class TeamSearch
    {
        public int LeagueID { get; set; }
        public DateTime FoundingDate { get; set; }
        public SearchDateDirection Direction { get; set; }
    }
}
