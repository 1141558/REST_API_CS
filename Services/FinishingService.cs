using System.Collections.Generic;
using System.Linq;
using nucleocs.Data;
using nucleocs.Data.Repositories;
using nucleocs.Data.Repositories.Interfaces;
using nucleocs.DTO;
using nucleocs.Models;
using nucleocs.MVDTO;
using nucleocs.Services.Interfaces;

namespace nucleocs.Services{
    public class FinishingService: IFinishingService{
        private readonly IFinishingRepository _repository;

        public FinishingService(IFinishingRepository repository)
        {
            _repository = repository;
        }

        public Finishing GetFinishingByID(int id){

            return _repository.GetById(id);
        }

        public List<MVFinishing> GetAllFinishings(){
            return _repository.GetAll();
        }

        public List<MVFinishing> GetFinishingByName(string name){

            return _repository.GetByName(name);
        }

        public Finishing GetFinishingByNameSingle(string name){

            return _repository.GetByNameSingle(name);
        }

        public Finishing CreateFinishing(FinishingDTO finishingDTO){
            var fn = new Finishing();
            var item = _repository.GetByNameSingle(finishingDTO.Name);
                            
            if(item == null){
                if(finishingDTO.Name.Length.Equals(null)){
                    return null;
                }else{
                    fn.Name = finishingDTO.Name;
                }                
                _repository.Create(fn);

                return fn;
            }else{
                return null;
            }

        }

        public Finishing UpdateFinishing(FinishingDTO finishingDTO){
            var finishing = _repository.GetById(finishingDTO.FinishingId);

            if (finishing == null)
            {
                return null;
            }else{
                if(finishingDTO.Name.Length.Equals(null)){
                    return null;
                }else{
                    finishing.Name = finishingDTO.Name;
                } 
                _repository.Update(finishing);
                
                return finishing;
            }
            
        }

        public bool DeleteFinishing(FinishingDTO finishingDTO){

            var item = _repository.GetById(finishingDTO.FinishingId);

            if (item == null)
            {
                return false;
            }else{
                _repository.Delete(item);

                return true;
            }
            
        }

    }
    
}