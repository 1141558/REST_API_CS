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

        public FinishingDTO GetFinishingByID(int id){
            var item = _repository.GetById(id);

            return FinishingDTO.From(item);
        }

        public List<FinishingDTO> GetAllFinishings(){
            return _repository.GetAll();
        }

        public List<FinishingDTO> GetFinishingByName(string name){

            return _repository.GetByName(name);
        }

        public FinishingDTO GetFinishingByNameSingle(string name){
            var item = _repository.GetByNameSingle(name);

            return FinishingDTO.From(item);
        }

        public FinishingDTO CreateFinishing(FinishingDTO finishingDTO){
            var fn = new Finishing();
            var item = _repository.GetByNameSingle(finishingDTO.Name);
                            
            if(item == null){
                if(finishingDTO.Name.Length.Equals(null)){
                    return null;
                }else{
                    fn.Name = finishingDTO.Name;
                }                
                _repository.Create(fn);

                return FinishingDTO.From(fn);
            }else{
                return null;
            }

        }

        public FinishingDTO UpdateFinishing(FinishingDTO finishingDTO){
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
                
                return FinishingDTO.From(finishing);
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