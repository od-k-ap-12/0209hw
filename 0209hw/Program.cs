using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0209hw
{
    class Program
    {
        static bool CreateForeignPassport()
        {

            try
            {
                Console.WriteLine("Enter passport code: ");
                string passportcode = Console.ReadLine();
                if (passportcode.All(char.IsDigit) == false)
                {
                    throw new Exception("Passport code doesn't allow anything except numbers");
                }
                if (passportcode.Length != 9)
                {
                    throw new Exception("Invalid passport code length");
                }

                Console.WriteLine("Enter first name: ");
                string firstname = Console.ReadLine();

                if (firstname.All(char.IsDigit) == true)
                {
                    throw new Exception("First name doesn't allow numbers");
                }
                if (!Char.IsUpper(firstname[0]))
                {
                    throw new Exception("First letter should be uppercase");
                }
                for (int i = 1; i < firstname.Length; i++)
                {
                    if (Char.IsUpper(firstname[i]))
                    {
                        throw new Exception("All letters except for the first one should be lowercase");
                    }
                }


                Console.WriteLine("Enter last name: ");
                string lastname = Console.ReadLine();

                if (firstname.All(char.IsDigit) == true)
                {
                    throw new Exception("First name doesn't allow numbers");
                }
                if (!Char.IsUpper(firstname[0]))
                {
                    throw new Exception("First letter should be uppercase");
                }
                for (int i = 1; i < firstname.Length; i++)
                {
                    if (Char.IsUpper(firstname[i]))
                    {
                        throw new Exception("All letters except for the first one should be lowercase");
                    }
                }

                Console.WriteLine("Enter the expiration date(month): ");
                string expirationmonth = Console.ReadLine();
                if (expirationmonth.All(char.IsDigit) == false)
                {
                    throw new Exception("Date doesn't allow anything except numbers");
                }
                if (expirationmonth.Length > 2 || expirationmonth.Length <= 0)
                {
                    throw new Exception("Invalid date length");
                }

                Console.WriteLine("Enter the expiration date(year): ");
                string expirationyear = Console.ReadLine();
                if (expirationyear.All(char.IsDigit) == false)
                {
                    throw new Exception("Date doesn't allow anything except numbers");
                }
                if (expirationyear.Length > 4 || expirationyear.Length <= 0)
                {
                    throw new Exception("Invalid date length");
                }
                var dateNow = DateTime.Now;
                var dateResult = new DateTime(Convert.ToInt32(expirationyear), Convert.ToInt32(expirationmonth), 1, 0, 0, 0);
                if (DateTime.Compare(dateResult, dateNow) > 0)
                {
                    throw new Exception("This passport is expired");
                }

                ForeignPassport pass = new ForeignPassport(firstname, lastname, dateResult,passportcode);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            Console.WriteLine("Credit card was successfully created.");
            return true;
        }

        static void Main(string[] args)
        {
           /* do
            {
                CreateForeignPassport();
            }
            while (CreateForeignPassport() == false);*/




            Console.WriteLine("Enter a logical statement:");
            string answer = Console.ReadLine();
            char[] charArray = answer.ToCharArray();
            string op=" ";
            int opindex1=0;
            int opindex2=0;
            string firstnumber="";
            string secondnumber="";
            try
            {
                int count = 0;
             for(int i=0;i<charArray.Length;i++)
                {
                    if (charArray[i] == '>')
                    {
                        count++;
                        op = ">";
                        opindex1 = i;
                        opindex2 = i;
                        if (charArray[i+1]== '=')
                        {
                            count++;
                            op = ">=";
                            opindex1 = i;
                            opindex2 = i+1;
                        }
                    }
                    else if (charArray[i] == '<')
                    {
                        count++;
                        op = "<";
                        opindex1 = i;
                        opindex2 = i;
                        if (charArray[i+1]== '=')
                        {
                            count++;
                            op = "<=";
                            opindex1 = i;
                            opindex2 = i + 1;
                        }
                    }
                    else if (charArray[i] == '='&&charArray[i-1]!='!'&&charArray[i-1]!='>' && charArray[i - 1] != '<')
                    {   count++;
                        op = "==";
                        opindex1 = i;
                        opindex2 = i+i;
                    }
                    else if (charArray[i] == '!')
                    {
                        if (charArray[i+1] != '=')
                        {
                            throw new Exception("Invalid operator");
                        }
                        else{
                            count++;
                            op = "!=";
                            opindex1 = i;
                            opindex2 = i + 1;
                        }
                    }
                    if (count > 1&&op!="==")
                    {
                        throw new Exception("Too many operators");
                    }
                    if (count > 2 && op == "==")
                    {
                        throw new Exception("Too many operators");
                    }
                }   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            for(int i = 0; i < charArray.Length; i++)
            {
                if (i < opindex1)
                {
                    firstnumber += charArray[i];
                }
                if (i > opindex2)
                {
                    secondnumber += charArray[i];
                }
            }
            /*Console.WriteLine(opindex1);
            Console.WriteLine(opindex2);
            Console.WriteLine(op);
            Console.WriteLine(firstnumber);
            Console.WriteLine(secondnumber);*/
            switch (op)
            {
                case ">":
                    Console.WriteLine(Convert.ToInt32(firstnumber) > Convert.ToInt32(secondnumber));
                    break;
                case "<":
                    Console.WriteLine(Convert.ToInt32(firstnumber) < Convert.ToInt32(secondnumber));
                    break;
                case ">=":
                    Console.WriteLine(Convert.ToInt32(firstnumber) >= Convert.ToInt32(secondnumber));
                    break;
                case "<=":
                    Console.WriteLine(Convert.ToInt32(firstnumber) <= Convert.ToInt32(secondnumber));
                    break;
                case "==":
                    Console.WriteLine(Convert.ToInt32(firstnumber) == Convert.ToInt32(secondnumber));
                    break;
                case "!=":
                    Console.WriteLine(Convert.ToInt32(firstnumber) != Convert.ToInt32(secondnumber));
                    break;
                default:
                    break;
            }

        }

    }
}
