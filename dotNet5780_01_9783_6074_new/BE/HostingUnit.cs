using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Linq;
using BE;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {

        public int HostingUnitKey
        {
            set;
            get;
        }
        public Host Owner { get; set; }
        public string HostingUnitName { set; get; }
        // tell the XmlSerializer to ignore this Property. 
        [XmlIgnore]
        public bool[,] Diary  {
            get;
            set;
        }
        //optional. tell the XmlSerializer to name the Array Element as'Board' 
        // instead of 'BoaredDto'
        [XmlArray("Diary")]
        public bool[] BoardDto
        {
            get { return Diary.Flatten();}
            set { Diary = value.Expand(13); } //13 is the number of rows in the matrix 
        }
        public int commission { set; get; }
        public placeOfVecation Area { get; set; }
        public City SubArea { get; set; }
        public typeOfVecation Type { set; get; }
        public int Adults { get; set; }    
        public int Children { set; get; }
        public int Persons { get { return Adults + Children; }}
        public bool  Pool { set; get; }
        public bool Jacuzzi { set; get; }
        public bool Garden { set; get; }
        public bool  ChildrensAttractions { set; get; }
        //public override string ToString()  
        //{
        //    string s=" The name of the hosting unit is:  "+ HostingUnitName + "\n  the ID number of the hosting unit is:  " + HostingUnitKey + "\n The owner of the hosting unit is: " + Owner.ToString();
        //    for (int i = 1; i <= 12; i++)
        //    {
        //        for (int j = 1; j <= 31; j++)
        //        {
        //            if (j != 1) //entry date
        //            {
        //                if (Diary[i,j] == true && Diary[ i, j - 1] == false)//[row,colone]
        //                {
        //                    s += j + "/" + i + "-";
        //                }
        //            }
        //            else //j=1
        //            {
        //                if ((Diary[1, 1] == true) || (Diary[i,1] == true && Diary[i-1,31] == false) || (Diary[i,j] == true && Diary[i-1,31] == false))
        //                {
        //                    s += j + "/" + i + "-";
        //                }
        //            }
        //            if ((j + 1) <= 31)  //Release Date
        //            {
        //                if (Diary[i,j] == true && Diary[i,j+1] == false)
        //                {
        //                    s += j + "/" + i + "\n";
        //                }
        //            }
        //            else
        //            {
        //                if (Diary[i,j] == true && Diary[i+1,1] == false)
        //                {
        //                    s += j + "/" + i + "\n";
        //                }
        //            }
        //        }
        //    }
        //    return s;

        //}

    }
}


  public static class Tools
{
    public static T[] Flatten<T>(this T[,] arr)
    {
        int rows = arr.GetLength(0);
        int columns = arr.GetLength(1);
        T[] arrFlattened = new T[rows * columns];
        for (int i = 0; i < rows; i++)

        {
            for (int j = 0; j < columns; j++)
            {
                var test = arr[i,j];

                arrFlattened[i*rows + j] = arr[i, j];
            }
        }
        return arrFlattened;
    } 
 
        public static T[,] Expand<T>(this T[] arr, int rows)
    {
        int length = arr.GetLength(0);
        int columns = length / rows;
        T[,] arrExpanded = new T[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                arrExpanded[i, j] = arr[i*rows + j];
            }
        }
        return arrExpanded;
    }
} 
 