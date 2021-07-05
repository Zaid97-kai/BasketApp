using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketApp
{
    public partial class Player
    {
        public int Experience
        {
            get
            {
                return DateTime.Now.Year - JoinYear.Year;
            }
        }
    }
}
