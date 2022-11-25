using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class TrackTime
    {
        public int Id { get; set; }
        public int IdTrack  { get; set; }
        public int IdCar { get; set; }
        public TimeSpan BestTimeLap { get; set; }
        public bool IsDeleted { get; set; }

        public List<TrackTime> Get_TrackTime()
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            return trackTimeDAL.Get_TrackTime(this);
        }

        public TrackTime Get_TrackTime(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            return trackTimeDAL.Get_TrackTime(id);
        }

        public int Set_TrackTime(TrackTime trackTime)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            return trackTimeDAL.Set_TrackTime(trackTime);
        }

        public int Delete_TrackTime(int id)
        {
            TrackTimeDAL trackTimeDAL = new TrackTimeDAL();
            return trackTimeDAL.Delete_TrackTime(id);
        }
    }
}