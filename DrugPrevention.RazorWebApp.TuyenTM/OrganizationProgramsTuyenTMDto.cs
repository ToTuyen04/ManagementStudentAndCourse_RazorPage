using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.RazorWebApp.TuyenTM
{
    public class OrganizationProgramsTuyenTMDto
    {
        public int OrganizationProgramTuyenTMID { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsSponsor { get; set; }
        public bool IsOrganizer { get; set; }
        public string ContributionDescription { get; set; }
        public string ProgramRole { get; set; }
        public decimal FundingAmount { get; set; }
        public string Feedback { get; set; }
        public string OrganizationName { get; set; }
        public string ProgramName { get; set; }

        // Navigation properties
        public OrganizationsTuyenTM? Organization { get; set; }
        public CommunityProgramsToanN? CommunityProgramsToanN { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
