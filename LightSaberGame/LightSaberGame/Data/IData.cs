using LightSaberGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSaberGame.Data
{
    public interface IData
    {
        Task<IEnumerable<HeroModel>> GetHeroes();

        Task<HeroModel> AddHero(HeroModel model);
    }
}
