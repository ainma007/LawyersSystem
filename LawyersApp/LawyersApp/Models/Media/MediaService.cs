using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Media
{
    public class MediaService
    {
        private LawyersEntities entities;

        public MediaService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<MediaViewControl> Read()
        {
            return entities.Media_Table
                .Select(db => new MediaViewControl
                {
                    MediaID  = db.MediaID,
                    MediaName = db.MediaName,
                    MediaDate = db.MediaDate.HasValue ? db.MediaDate.Value : default(DateTime),
                    PartnerName = db.PartnerName,
                    MediaNumber = db.MediaNumber,
                    minutes = db.minutes,
                    url =  db.url,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },
                    MediaTypeID = db.MediaTypeID,

                    MediaType = new MediaTypeForingKey()
                    {
                        MediaTypeID = db.MediaType_Table.MediaTypeID,
                        MediaTypeName = db.MediaType_Table.MediaTypeName,
                    },

                    ProjectID = db.ProjectID,

                });
        }
        public void Create(MediaViewControl db)
        {
            var entity = new Media_Table();

            entity.MediaName = db.MediaName;
            entity.MediaDate = (DateTime)db.MediaDate.Date;

            entity.PartnerName = db.PartnerName;
            entity.MediaNumber = db.MediaNumber;

            entity.minutes = db.minutes;
            entity.url = db.url;
            entity.UserID = db.UserID;
            entity.MediaTypeID = db.MediaTypeID;
            entity.ProjectID = db.ProjectID;
            entities.Media_Table.Add(entity);
            entities.SaveChanges();

            db.MediaID = entity.MediaID;
        }

        public void Update(MediaViewControl db)
        {
            var entity = new Media_Table();
            entity.MediaID = db.MediaID;

            entity.MediaName = db.MediaName;
            entity.MediaDate = (DateTime)db.MediaDate.Date;

            entity.PartnerName = db.PartnerName;
            entity.MediaNumber = db.MediaNumber;

            entity.minutes = db.minutes;
            entity.url = db.url;
            entity.UserID = db.UserID;
            entity.MediaTypeID = db.MediaTypeID;
            entity.ProjectID = db.ProjectID;
            entities.Media_Table.Attach(entity);

            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(MediaViewControl db)
        {
            var entity = new Media_Table();

            entity.MediaID = db.MediaID;

            entities.Media_Table.Attach(entity);

            entities.Media_Table.Remove(entity);

            entities.SaveChanges();
        }

        public IEnumerable<MediaTypeForingKey> GetMediaType()
        {
            return entities.MediaType_Table.Select(province => new MediaTypeForingKey
            {
                MediaTypeID = province.MediaTypeID,
                MediaTypeName = province.MediaTypeName


            });
        }

        public void Dispose()
        {
            entities.Dispose();
        }

    }
}