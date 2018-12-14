using System.Collections.Generic;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;

namespace nucleocs.Services.Interfaces{
    public interface IMaterialService{
        Material GetMaterialByID(int id);
        List<MVMaterial> GetAllMaterials();
        List<MVMaterial> GetMateriaByName(string name);
        Material GetMateriaByNameSingle(string name);
        Material CreateMaterial(MaterialDTO materialDTO);
        Material UpdateMaterial(MaterialDTO materialDTO);
         bool DeleteMaterial(MaterialDTO materialDTO);
    }
}