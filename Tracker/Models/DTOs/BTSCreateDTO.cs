using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tracker.Entity;

namespace Tracker.Models.DTOs
{
    public class BTSCreateDTO
    {
        /// <summary>
        /// Site Id
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Site Id of a base station is required")]
        [StringLength(10, ErrorMessage = "Maximum character count of 10 is exceeded")]
        [Display(Name = "Base Station")]
        public string BTSName { get; set; }


        /// <summary>
        /// Address or landmark of the location of the base station
        /// </summary>
        [StringLength(300, ErrorMessage = "Maximun character count of 300 is exceeded")]
        [Display(Name = "Address/Landmark")]
        public string? LocationAddress { get; set; }


        /// <summary>
        /// The Id of the state
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State State { get; set; }

        public List<MPLSPoPDTO>? DCNRouters { get; set; }

        /// <summary>
        /// The latitude of the base station
        /// </summary>
        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }


        /// <summary>
        /// The longitude of the base station
        /// </summary>
        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// The calculated coordinates values
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Coordinates")]
        public string? Coordinates { get; set; }

        public List<NetworkSwitch>? Switches { get; set; }

        /// <summary>
        /// Method that converts decimal coordinates to deg, min and sec
        /// </summary>
        /// <returns>The coordinates in degrees minutes seconds</returns>
        private string? CalculateCoord()
        {

            string latitudeCoord, longitudeCoord;
            if (Latitude.HasValue && Longitude.HasValue)
            {
                int degrees;
                double minutes, seconds;
                // set decimal_degrees value here
                if (Latitude.Value.ToString().IndexOf('.') != -1)
                {
                    degrees = Convert.ToInt32(Latitude.Value.ToString().Split(".")[0]);
                    minutes = (Latitude.Value - degrees) * 60;
                    seconds = (minutes - Math.Floor(minutes)) * 60.0;

                    // get rid of fractional part
                    minutes = Math.Floor(minutes);
                    seconds = Math.Round(seconds, 2);
                    latitudeCoord = $"{degrees}\u00b0{minutes}'{seconds}\"N";
                }
                else
                {
                    latitudeCoord = $"{Latitude.Value}\u00b00'0\"N";
                }

                if (Longitude.Value.ToString().IndexOf('.') != -1)
                {
                    degrees = Convert.ToInt32(Longitude.Value.ToString().Split(".")[0]);
                    minutes = (Longitude.Value - degrees) * 60;
                    seconds = (minutes - Math.Floor(minutes)) * 60.0;

                    // get rid of fractional part
                    minutes = Math.Floor(minutes);
                    seconds = Math.Round(seconds, 2);
                    longitudeCoord = $"{degrees}\u00b0{minutes}'{seconds}\"E";
                }
                else
                {
                    longitudeCoord = $"{Latitude.Value}\u00b00'0\"E";
                }
                return $"{latitudeCoord} {longitudeCoord}";
            }
            else
            {
                return null;
            }
        }
    }
}
