using Epam.Forums.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Forums.LogicContracts
{
    public interface IImageLogic
    {
        bool AddImageToUser(int ID, Photo photo);
        bool AddImageToTopic(int ID, Photo photo);

        Photo GetSmallPhoto(int ID);
    }
}
