using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface IMaterialService{
        MaterialDTO GetMaterialByID(int id);
        List<MaterialDTO> GetAllMaterials();
        List<MaterialDTO> GetMateriaByName(string name);
        MaterialDTO GetMateriaByNameSingle(string name);
        MaterialDTO CreateMaterial(MaterialDTO materialDTO);
        MaterialDTO UpdateMaterial(MaterialDTO materialDTO);
        bool DeleteMaterial(MaterialDTO materialDTO);
    }
}