using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface IFinishingService{
        Finishing GetFinishingByID(int id);
        List<MVFinishing> GetAllFinishings();
        List<MVFinishing> GetFinishingByName(string name);
        Finishing GetFinishingByNameSingle(string name);
        Finishing CreateFinishing(FinishingDTO finishingDTO);
        Finishing UpdateFinishing(FinishingDTO finishingDTO);
        bool DeleteFinishing(FinishingDTO finishingDTO);
    }
}