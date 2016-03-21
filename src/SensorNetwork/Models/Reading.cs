using SensorNetwork.Models.RepositoryPattern;
using System;
using System.ComponentModel.DataAnnotations;

namespace SensorNetwork.Models
{
    public class Reading
    {
        //public Reading(ISensorNetRepository repos)
        //{
        //}
        public long ReadingID { get; set; }

        public int Value { get; set; }
        
        public DateTime Time { get; set; }
    }
}