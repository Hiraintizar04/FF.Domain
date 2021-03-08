using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FF.Data.Models;


namespace FF.Data.Repository
{
    public class ApplicantRepository
    {
        private readonly ApplicantContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ApplicantRepository(ApplicantContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Asynchronously saves all changes made in this _context to the underlying inmemory database.
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns></returns>
        public async Task<int> AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// this method will fetch all the applicant records which were posted 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Applicant> GetAllApplicants()
        {
            return _context.Applicants.ToList();
        }
        /// <summary>
        /// this method will fetch  the applicant record by using its specific id , it will only get that applicant 
        /// only if its id exists in the context
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicant"></param>
        /// <returns> </returns>
        public bool GetApplicantById(int id, out Applicant applicant)
        {
            applicant = _context.Applicants.Find(id);
            return (applicant != null);
        }
        /// <summary>
        /// if the id exists in the context in the applicant list, and this method will update the required fields/properties 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicant"></param>
        /// <returns> updated applicant properties</returns>
        public async Task<int> UpdateApplicant(int id, Applicant applicant)
        {
            Applicant temp;
            temp = _context.Applicants.Find(id);
            if (temp.ApplicantId != 0)
            {
                temp.Name = applicant.Name;
                temp.FamilyName = applicant.FamilyName;
                temp.Address = applicant.Address;
                temp.Age = applicant.Age;
                temp.EmailAddress = applicant.EmailAddress;
                temp.CountryOfOrigin = applicant.CountryOfOrigin;
                temp.Hired = applicant.Hired;
            }
            return await _context.SaveChangesAsync();
            
        }
        /// <summary>
        /// if the id exists in the context in the applicant list, then this method will cause it to be detached from the context.
        /// if the id doesnt match the existing ids it will not delete anything
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteApplicant(int id)
        {
            Applicant ad;
            ad = _context.Applicants.Find(id);
            _context.Applicants.Remove(ad);
            return await _context.SaveChangesAsync();
        }



    }
}
