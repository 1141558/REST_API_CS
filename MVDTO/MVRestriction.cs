using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nucleocs.Models;
using nucleocs.Models.Strategy;

namespace nucleocs.MVDTO
{
    public class MVRestriction{
        public int RestrictionId { get; set;}

        public MVRestriction(){}
    }
}