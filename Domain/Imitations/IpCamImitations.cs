using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Imitations
{
    public class IpCamImitations : ICamera
    {
        public IQueryable<IpCam> Items
        {
            get
            {
                return (new List<IpCam> {
                    new IpCam { Id = 1, Adress = "http://148.61.63.218/axis-cgi/mjpg/video.cgi"},
                }).AsQueryable();
            }

        }
    }
}