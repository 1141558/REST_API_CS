using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using nucleocs.Data;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.Data.Repositories;
using nucleocs.Services.Interfaces;

namespace nucleocs.Services{
    public class MaterialService : IMaterialService{
        private readonly IMaterialRepository _repositoryMaterial;
        private readonly IFinishingRepository _repositoryFinishing;

        public MaterialService(IMaterialRepository repositoryMaterial, IFinishingRepository repositoryFinishing){
            _repositoryMaterial = repositoryMaterial;
            _repositoryFinishing = repositoryFinishing;
        }

        public MaterialDTO GetMaterialByID(int id){

            var item = _repositoryMaterial.GetById(id);

            if (item == null)
            {
                return null;
            }else{
                return MaterialDTO.From(item);
            }
        }

        public List<MaterialDTO> GetAllMaterials(){
           return _repositoryMaterial.GetAll();
        }

        public List<MaterialDTO> GetMateriaByName(string name){

           return _repositoryMaterial.GetByName(name);
        }

         public MaterialDTO GetMateriaByNameSingle(string name){
            var item = _repositoryMaterial.GetByNameSingle(name);
            
           return MaterialDTO.From(item);
        }

        public MaterialDTO CreateMaterial(MaterialDTO materialDTO){
            
            var mtl = new Material();

            var item = _repositoryMaterial.GetByNameSingle(materialDTO.Name); //Verifica se já existe algum material com o nome passado por parametro

            if(item == null){ //se não existir adicona um novo material com os seus acabamentos
                if(materialDTO.Name.Length.Equals(null)){
                    return null;
                }else{
                    mtl.Name = materialDTO.Name;
                }                

                ICollection<MaterialFinishing> icolMatF = new List<MaterialFinishing>();            
            
                foreach(Finishing fn in materialDTO.Finishings){ //preencher os acabamentos
                    var finishing = _repositoryFinishing.GetById(fn.FinishingId);
                    var mF = new MaterialFinishing();
                    if(finishing != null){
                        mF.Finishing = finishing;
                        mF.Material = mtl;
                        icolMatF.Add(mF);
                    }else{
                        return null;
                    }                        
                }
                mtl.MaterialFinishings = icolMatF;
                _repositoryMaterial.Create(mtl);

                return MaterialDTO.From(mtl);
            }else{
                return null;
            }
        }

        public MaterialDTO UpdateMaterial(MaterialDTO materialDTO){
            var item = _repositoryMaterial.GetById(materialDTO.MaterialId);

            if (item == null)
            {
                return null;
            }

            //Remover os dados anteriores onde consta a lista de acabamentos
            ICollection<MaterialFinishing> icolMtFremove = new List<MaterialFinishing>();

            icolMtFremove = _repositoryMaterial.IcolMtFremove(materialDTO.MaterialId);

            foreach(var cena in icolMtFremove){
                _repositoryMaterial.RemoveMaterialFinishings(cena);
            }
            
            //Adicionar os novos dados
            if(materialDTO.Name.Length.Equals(null)){
                    return null;
                }else{
                    item.Name = materialDTO.Name;
                }  
           
            ICollection<MaterialFinishing> icolMatF = new List<MaterialFinishing>();

            foreach(Finishing fn in materialDTO.Finishings){//preencher os acabamentos
                var finishing = _repositoryFinishing.GetById(fn.FinishingId);
                var mF = new MaterialFinishing();
                if(finishing != null){
                    mF.Finishing = finishing;
                    mF.Material = item;
                    icolMatF.Add(mF);
                }else{
                    return null;
                }
                    
            }

            item.MaterialFinishings = icolMatF;
            _repositoryMaterial.Update(item);
            
            return MaterialDTO.From(item);
        }

        public bool DeleteMaterial(MaterialDTO materialDTO){
            
            var item = _repositoryMaterial.GetById(materialDTO.MaterialId);
            if (item == null)
            {
                return false;
            }
            _repositoryMaterial.Delete(item);
            
            return true;
        } 

    }
    
}