using MockingUnitTestsDemoApp.Impl.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MockingUnitTestsDemoApp.Impl.Models
{
    public class TeamSearch
    {
        [Required]
        [Range(1, 1000)]
        public int LeagueID { get; set; }
        public DateTime FoundingDate { get; set; }
        public SearchDateDirection Direction { get; set; }

        public List<Team> Results { get; set; }
    }
}
