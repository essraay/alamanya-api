using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ApplicationForm : IEntity
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string BirthPlace { get; set; }
        public string Adress { get; set; }
        public int ProvincesId { get; set; }
        public int DistrictId { get; set; }
        public int NationalityId { get; set; }
        public bool DualNationality { get; set; }
        public int GenderId { get; set; }
        public int AgeRangeId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int GraduationId { get; set; }
        public int GermanLevelId { get; set; }
        public bool DrivingLicense { get; set; }
        public bool Passport { get; set; }
        public int BalanceId { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }
        public string DisabilityStatus { get; set; }
        public string ChronicDisease { get; set; }
        public int CategoryId { get; set; }
        public string EmergencyPersonFullName { get; set; }
        public string EmergencyPersonPhone { get; set; }
        public string EmergencyPersonEmail { get; set; }
        public string EmergencyPersonDegreeOfProximity { get; set; }
        public string CvFile { get; set; }
        public string ContractFile { get; set; }
        public string OtherFile { get; set; }



        public virtual Balance Balance { get; set; }
        public virtual Category Category { get; set; }
        public virtual District District { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual AgeRange AgeRange { get; set; }
        public virtual Graduation Graduation { get; set; }
        public virtual GermanLanguageLevel GermanLevel { get; set; }
        public virtual Provinces Provinces { get; set; }
        public virtual List<AppSelectedLanguage> AppSelectedLanguages { get; set; }

    }
}
