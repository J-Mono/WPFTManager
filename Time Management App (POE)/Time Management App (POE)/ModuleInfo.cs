using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Management_App__POE_
{
    public class ModuleInfo
    {
        //Encapsulation or getters & setters, ensures data is hidden from users(w3schools, 2021)
        //some getters and setters that will be use in the modules class
        //string get and set
        public string Module_code { get; set; }
        public string Name { get; set; }
        public string Credit{ get; set; }
        public string Class_Hours { get; set; }
        public string study_hours_required { get; set; }

        //int get and set
        public int Nr_of_weeks { get; set; }
        public int hoursStudied { get; set; }
        public int RemainingStudyHours { get; set; }
    }
}
