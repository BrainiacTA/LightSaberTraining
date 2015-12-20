using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.Model
{
    public class HeroGetResponse
    {
        public IEnumerable<HeroModel> Result { get; set; }
    }
}
