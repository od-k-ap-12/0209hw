using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0209hw
{
    class ForeignPassport
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Code { get; private set; }
        public DateTime Expiration { get; private set; }

        public ForeignPassport(string _FirstName, string _LastName, DateTime _Expiration, string _Code)
        {
            FirstName = _FirstName;
            LastName = _LastName;
            Expiration = _Expiration;
            Code = _Code;
        }
        public virtual void Print()
        {
            Console.WriteLine("First Name: " + FirstName + "\nLast Name:" + LastName + "\nExpiration:" + Expiration + "\nCode:" + Code);
        }
        public override string ToString()
        {
            return "First Name: " + FirstName + "\nLast Name:" + LastName + "\nExpiration:" + Expiration + "\nCode:" + Code;
        }
    }
}
