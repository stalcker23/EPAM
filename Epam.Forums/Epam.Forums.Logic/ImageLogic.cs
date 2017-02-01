using Epam.Forums.DalContracts;
using Epam.Forums.Entities;
using Epam.Forums.LogicContracts;
using Epam.Forums.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.Logic
{
    public class ImageLogic : IImageLogic
    {
        private IImageDao imageDao;

        public ImageLogic()
        {
            
            imageDao = DaoProvider.ImageDao;
            
        }

        public bool AddImageToUser(int ID, Photo photo)
        {
            try
            {
                return imageDao.AddUsersPhoto(ID, photo);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
        public bool AddImageToTopic(int ID, Photo photo)
        {
            try
            { 
            return imageDao.AddTopicPhoto(ID, photo);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
        public Photo GetSmallPhoto(int ID)
        {
            try
            {
                return imageDao.GetSmallPhoto(ID);
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }
    }
}
