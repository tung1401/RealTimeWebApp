using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealTimeWebApp.Models;
using RealTimeWebApp.Services;

namespace RealTimeWebApp.Api
{
    public class MapController : Controller
    {
        public readonly MapServices service = new MapServices();
        public ActionResult<List<LocationMap>> Message()
        {          
            var list = service.GetAll();
            Response.ContentType = "text/event-stream";
            var bytes = Encoding.UTF8.GetBytes(string.Format("data: {0}\n\n", JsonConvert.SerializeObject(list)));
            Response.Body.Write(bytes);
            Response.Body.Close();
            return list;
        }

        [HttpPost]
        public JsonResult AddMap(MapItem MapItem)
        {
            service.Add(new LocationMap
            {
                LocationMapName = MapItem.Name,
                Latitude = MapItem.Lat,
                Longitude = MapItem.Long,
                LocationMapImageUrl = MapItem.Url
            });

            return Json("success");
        }
    }

    public class MapItem
    {
        public string Name { get; set; }
      //  public string LocationMapDescription { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Url { get; set; }
    }

    public class LocationModel
    {
       public bool Update { get; set; }
       public List<LocationMap> LocationMapList { get; set; }
    }
}


/*
1. run db table
CREATE TABLE [dbo].[LocationMap](  
    LocationMapId	INT IDENTITY(1,1) NOT NULL,  
    LocationMapName   NVARCHAR(MAX) NULL,
	LocationMapDescription   NVARCHAR(MAX) NULL,
	Latitude NVARCHAR(50) NULL,  
	Longitude NVARCHAR(50) NULL,
	LocationMapImageUrl   NVARCHAR(MAX) NULL  
		
	CONSTRAINT [PK_LocationMap] PRIMARY KEY CLUSTERED ([LocationMapId] ASC),
) 

2.

    PM> Scaffold-DbContext "Server=.\SQLExpress;Database=MyMap;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

3. create map service

4. add SSE to html


5. insert data in db

INSERT INTO [LocationMap] VALUES('CMU','Chiangmai University','','',null)
INSERT INTO [LocationMap] VALUES('MJU','Maejo University','','',null)
     
*/
