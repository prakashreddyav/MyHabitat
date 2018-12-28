using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Relations
    {
        Gender _gender;       
        public int RelationId { get; set; }
        public string RelationName { get; set; }
        public string RelationGender
        {
            private get
            {
                return _gender.ToString();
            }
            set
            {
                Enum.TryParse<Gender>(value,out _gender);
            }
        }
        public Gender RelationGenderEnum
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }
    }
}
