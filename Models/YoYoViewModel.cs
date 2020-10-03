using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoYo_Web_App.Models
{
    public class YoYoViewModel
    {
        public IList<FintessRatingModel> fintessRatinngMetaData { get; set; }

        public IList<PlayersModel> pleayersList { get; set; }
    }
}
