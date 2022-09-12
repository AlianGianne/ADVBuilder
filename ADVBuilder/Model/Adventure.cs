﻿using Gema2022.Class;
using Gema2022.CommonClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADVBuilder.Model
{
    public class Adventure : cOggettoData
    {
        private const string SELECTBYID = "SelectById";

        public List<AdventureData> List = new List<AdventureData>();

        public Adventure()
        {
            Settings(this.GetType().Name);
            ReadData();
            ReadList(List);
            ///////////////
            ReadRooms();
        }

        public Adventure(int pIdAdv)
        {
            Settings(this.GetType().Name);
            ReadData(pIdAdv);
            ReadList(List);
            ///////////////
            ReadRooms();
        }

        private void ReadData(int pIdAdv)
        {
            if (Open())
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID", pIdAdv);
                Table = ExecuteQuery(SELECTBYID, param, PercorsoFileXml);
                Close();
            }
        }

        public void ReadRooms()
        {
            foreach (AdventureData ad in List)
            {
                Room rm = new Room(ad.Id);
                ad.Rooms = rm.List;
            }
        }
    }

    public class AdventureData
    {
        #region "Properties"

        [cAttributes(Name = "Id")]
        public int Id { get; set; }

        [cAttributes(Name = "Title")]
        public string Title { get; set; }                   //Titolo

        [cAttributes(Name = "SubTitle")]
        public string SubTitle { get; set; }

        [cAttributes(Name = "Description")]
        public string Description { get; set; }             //Descrizione

        [cAttributes(Name = "ShortDescription")]
        public string ShortDescription { get; set; }        //Descrizione breve

        [cAttributes(Name = "Version")]
        public string Version { get; set; }

        [cAttributes(Name = "Author")]
        public string Author { get; set; }

        public List<RoomData> Rooms { get; set; }

        [cAttributes(Name = "CurrentRoom")]
        public int CurrentRoom { get; set; }

        public string Direction { get; set; }
        public List<string> Days { get; set; } = new List<string>() { "Lunadi", "Martedi", "Mercuriodi", "Giovedi", "Veneredi", "Saturnodi", "Soledi",
                                                                      "Uranodi", "Nettunodi", "Plutonedi", "Iodi", "Europadi", "Ganimededi", "Terradi",
                                                                      "Callistodi", "Titanodi", "Readi", "Giapetodi", "Dionedi", "Tetidi", "Iperionedi",
                                                                      "Mimasdi", "Enceladodi", "Phoebedi", "Gianodi", "Titaniadi", "Oberondi", "Metisdi"};
        public List<string> Months { get; set; } = new List<string>() { "Unembre", "Duembre", "Treembre", "Quattrembre", "Cinquembre", "Seiembre",
                                                                        "Settembre", "Ottembre", "Novembre", "Diecembre", "Undicembre", "Dodicembre"};
        public int Year { get; set; } = 110;
        public int Month { get; set; } = 11;
        public int Day { get; set; } = 27;
        public int Hour { get; set; } = 23;
        public int Minute { get; set; }
        public int Second { get; set; }

        public string CurrentTime { get { return string.Format("{0}:{1}", Hour.ToString("00"), Minute.ToString("00")); } }
        public string CurrentDate { get { return string.Format("{0} {1} {2} nell'anno di Condorian {3}", Days[Day], (Day + 1).ToString("00"), Months[Month], Year.ToString("00")); } }
        public string CompleteDate { get { return string.Format("{0} {1}", CurrentDate, CurrentTime); } }
        public string CurrentDayTime
        {
            get { return string.Format("{0}",
                        Hour >= 0 && Hour < 6 ? 
                            "Notte" : 
                        Hour >= 6 && Hour < 12 ? 
                            "Mattino" : 
                        Hour >= 12 && Hour < 18 ? 
                            "Pomeriggio" : 
                        "Sera");
            }
        }


        #endregion "Properties"

        #region "Methods"
        public bool IncrementTime()
        {
            bool ret = false;
            if (Second < 59)
            {
                Second += 30;
            }
            else
            {
                Second = 0;
                if (Minute < 59)
                {
                    Minute++;
                }
                else
                {
                    Minute = 0;
                    if (Hour < 22)
                    {
                        Hour++;
                    }
                    else
                    {
                        Hour = 0;
                        if (Day < 27)
                        {
                            Day++;
                        }
                        else
                        {
                            Day = 0;
                            if (Month < 11)
                            {
                                Month++;
                            }
                            else
                            {
                                Month = 0;
                                Year++;
                                ret = true;
                            }
                        }
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// Restituisce la descrizione lunga della Room
        /// </summary>
        /// <returns>string: descrizione lunga della Room</returns>
        public string ViewRoom()
        {
            return ActualRoom().Description;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RoomData ActualRoom()
        {
            return Rooms.Where(r => r.Id == CurrentRoom).FirstOrDefault();
        }
        #endregion "Methods"
    }
}