using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using F1_mvc.Models;

namespace F1_mvc.Classes
{
    public class ConstructorComparer : IEqualityComparer<constructors>
    {
        public bool Equals(constructors x, constructors y)
        {
            if (x.constructorId == y.constructorId
                    && x.constructorRef.ToLower() == y.constructorRef.ToLower())
                return true;

            return false;
        }
        
        public int GetHashCode(constructors obj)
        {
            return obj.constructorId.GetHashCode();
        }
    }
}