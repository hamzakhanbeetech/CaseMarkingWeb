using Case_Marking_Web_Applications.Models.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case_Marking_Web_Application.Interfaces
{
    public interface ICourtsService
    {
        public List<Court> GetCourts(int userId);
        public Court AddCourt(AddCourtRequest court);
        public Court? DeleteCourt(int id);
    }
}
