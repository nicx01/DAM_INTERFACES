using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBackRules.Utils
{
    public static class Constantes
    {
        public const string POKE_TYPE_URL= "https://pokeapi.co/api/v2/type/";
        public const string POKE_HISTORIC_URL= "https://localhost:7119/Pokemon";
        public const string POKE_TEAM_URL= "https://localhost:7119/Pokemon/GetTeam";
        public const int MAX_POKE_ITEMS = 150;
        public const string MISSINGNO_IMAGE_PATH = "../Resources/missingNo.jpg";
        public const string CHECK_IMAGE_PATH = "../Resources/check_icon.png";
        public const string ERROR_IMAGE_PATH = "../Resources/error_icon.jpg";
    }
}
