using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.DalContracts
{
    public interface IImageDao
    {
        bool AddUsersPhoto(int ID, Photo photo);
        bool AddTopicPhoto(int ID, Photo photo);
        Photo GetSmallPhoto(int ID);
    }
}
