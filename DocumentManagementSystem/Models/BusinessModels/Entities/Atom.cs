using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities
{
    public class Atom
    {
        private Atom()
        {

        }





        private static Atom uniqueInstance;

        private static readonly object lockerInitial = new object();





        public static Atom GetInstance()
        {
            if (uniqueInstance == null)
                lock (lockerInitial)
                    if (uniqueInstance == null)
                        uniqueInstance = new Atom();

            return uniqueInstance;
        }
    }
}