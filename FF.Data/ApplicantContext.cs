using Microsoft.EntityFrameworkCore;
using FF.Data.Models;
namespace FF.Data
{
    public class ApplicantContext : DbContext
    {
        public ApplicantContext(DbContextOptions<ApplicantContext> options
            ) : base(options)

        {

        }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
