using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface IFinishingService{
        FinishingDTO GetFinishingByID(int id);
        List<FinishingDTO> GetAllFinishings();
        List<FinishingDTO> GetFinishingByName(string name);
        FinishingDTO GetFinishingByNameSingle(string name);
        FinishingDTO CreateFinishing(FinishingDTO finishingDTO);
        FinishingDTO UpdateFinishing(FinishingDTO finishingDTO);
        bool DeleteFinishing(FinishingDTO finishingDTO);
    }
}