using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.DAL;

namespace WebApi2.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }

        public bool IsDeleted { get; set; }

        public List<Track> Get_Track()
        {
            TrackDAL trackDAL = new TrackDAL();
            return trackDAL.Get_Track(this);
        }

        public Track Get_Track(int id)
        {
            TrackDAL trackDAL = new TrackDAL();
            return trackDAL.Get_Track(id);
        }

        public int Set_Track(Track track)
        {
            TrackDAL trackDAL = new TrackDAL();
            return trackDAL.Set_Track(track);
        }

        public int Delete_Track(int id)
        {
            TrackDAL trackDAL = new TrackDAL();
            return trackDAL.Delete_Track(id);
        }
    }
}