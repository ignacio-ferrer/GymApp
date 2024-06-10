using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GymApp
{
    internal class InformacionNutrientes
    {
        public class NutrientInfo
        {
            [JsonPropertyName("ENERC_KCAL")]
            public double Calories { get; set; }

            [JsonPropertyName("PROCNT")]
            public double Protein { get; set; }

            [JsonPropertyName("FAT")]
            public double Fat { get; set; }

            [JsonPropertyName("CHOCDF.net")]
            public double Carbohydrates { get; set; }
        }

        public class NutritionDataResponse
        {
            [JsonPropertyName("totalNutrients")]
            public NutrientInfo TotalNutrients { get; set; }
        }
    }
}
