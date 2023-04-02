using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForPoe
{
    public class CalculateSelfStudy
    {
        //method to calculate the study hours weekly
        public int calcStudyHours(int Credits, int Nr_of_weeks, int class_hp)
        {
            //weekly study hours = credits time 10. 
            //then that ansswer is divided by the number of weeks
            //then that answer is subtracted by the class hours
            return(Credits * 10 / Nr_of_weeks) - class_hp;
        }
    }
}
