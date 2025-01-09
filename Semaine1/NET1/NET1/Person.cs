using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace NET1
{
    [Serializable]
    public class Person 
    {


    private readonly string name;
	private readonly string firstname;
	private readonly DateTime birthDate;
	
	public virtual string Name
    {
        get { return name; }
    }

    public string Firstname
    {
        get { return firstname; }
    }

    public string BirthDate
    {
         get 
         {
                return birthDate.ToString("dd-M-yyyy");
         }
        
    }


    public Person(string name, string firstname, DateTime birthDate)
    {
        this.name = name;
        this.firstname = firstname;
        this.birthDate = birthDate;
    }

    
    public override string ToString()
    {
        return "Person [name = " + name + ", firstname = " + firstname + ", birthDate =  " + birthDate + "]";
    }


}
}
