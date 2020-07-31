using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Lambda
{
    public class AnonymousCass
    {
        Person person = new Person()
        {
            Id = 1,
            Name = "cc",
            Desciption = "帅气"
        };

        
        public void GetNewPerson()
        {
            var person2 = new
            {
                Id = 1,
                Name = "cc",
                Desciption = "帅气"
            };
        }
        
        //1:30:00s
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public Person()
        {
            
        }
    }
}
