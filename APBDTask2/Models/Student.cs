using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    public class Student
    {

        /* name = Paweł,
         * surname = Nowak1,
         * field_Of_Study = Informatyka dzienne
         * learning_style = Dzienne
         * student_Number = 459
         * Enrolment_Date = 2000-02-12,
         * Email = 1@pjwstk.edu.pl,
         * Mother_Name = Alina,
         * Father_Name = Adam
         */
        // [XmlElement(ElementName = "e-mail")]
        
        public string Email { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FieldOfStudy { get; set; }
        public string LearningStyle { get; set; }
        [XmlAttribute(attributeName: "Student_Number")]
        public string StudentNumber { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }

/*
        private string _surname; // if write an private field. ıts getter and setter format.
        public string Surname
        { get {return _surname;}
          set{
                 //if (value == null) throw new ArgumentException();
                //_surname = value;

                // if surname is null, ?? means if null, it throws an exception. if not, initialize it with the value. 
                _surname = value ?? throw new ArgumentException(); 
            }
        }*/ 

    }
}
