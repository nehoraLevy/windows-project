using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Possibility
    {
        necessary,possible,uninterested
    }
    public enum typeOfVecation
    {
        tent,hotel_room,apartment,zimmer,accommodation_apartment
     }
    public enum placeOfVecation
    {
       all_cities,north,south,jerusalem
    }
    public enum statusOfTheOrder
    {
        not_deal_with, send_email, The_vacantion_close, The_vacantion_cancel, close_because_expired
    }
    public enum City
    {
        Askelon,Tsfat,Ashdod,Eilat,Beer_Sheva,Jerusalem,Tel_Aviv
    }
    public enum statusMakeChange
    {
        open,deal_close_with_the_site, close_because_expired
    }

   
}
