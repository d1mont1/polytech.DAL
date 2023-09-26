using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polytech.DAL.model
{
    public class Client
    {
        public Client() : this(0)
        {
        }
        public Client(int Id) : this(Id, DateTime.Now)
        {
        }
        public Client(int Id, DateTime CreateDate) :
            this(Id, CreateDate, "")
        {
        }
       
        public Client(int Id, DateTime CreateDate, string PathToImage)
        {
            this.Id = Id;
            this.CreateDate = CreateDate;
            this.PathToImage = PathToImage;

        }
        public int Id
        {
            get;
            /*{
                return Id;
            }*/
            set;
            /*{
                if (value < 0)
                {
                    Id = 0;
                }
                else Id = value;
            }*/
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - CreateDate.Year);
            }
           
        }
        public string Fullname
        {
            get
            {
                return string.Format("{0} {1} {2}", Fname, Sname, Lname);
            }
        }
        public string ShortName
        {
            get
            {
                if (string.IsNullOrEmpty(Lname))
                {
                    return string.Format("{0} {1}", Fname, Sname[0]);

                }
                else
                    return string.Format("{0} {1} {2}", Fname, Sname[0], Lname[0]);
            }
        }
        public string Phone { get; set; }

        public int Sex { get; set; }
        public string PathToImage { get; set; }
        public Addres Addres { get; set; }

        public Account[] Accounts   { get; set; }


    }
}
