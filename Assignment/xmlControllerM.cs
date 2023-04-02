using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Assignment
{
    //MEMBERS XML CONTROLLER
    public class XmlControllerM
    {
        //uses members.xml load pathway
        string path = "Members.xml";
        public void AddMember(Member newMember)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode ROOT = doc.SelectSingleNode("/members");
            XmlNode Member = doc.CreateElement("member");
            XmlNode FirstName = doc.CreateElement("first_name");
            XmlNode SecondName = doc.CreateElement("second_name");
            XmlNode Email = doc.CreateElement("email");
            XmlNode Phone = doc.CreateElement("phone");
            XmlNode LibraryID = doc.CreateElement("library_card_number");

            FirstName.InnerText = newMember.firstName;
            SecondName.InnerText = newMember.lastName;
            Email.InnerText = newMember.email;
            Phone.InnerText = newMember.phone;
            LibraryID.InnerText = newMember.libraryID;

            Member.AppendChild(FirstName);
            Member.AppendChild(SecondName);
            Member.AppendChild(Email);
            Member.AppendChild(Phone);
            Member.AppendChild(LibraryID);

            ROOT.AppendChild(Member);
            doc.Save(path);
        }

        public bool deleteMember(string libraryID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.SelectSingleNode("/members/member[library_card_number = '" + libraryID + "']");
            if (node == null)
            {
                return false;
            }
            node.ParentNode.RemoveChild(node);
            doc.Save(path);
            return true;

        }

        public void updateMember(string libraryID, Member newMember)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode oldMember = doc!.SelectSingleNode("/members/member[library_card_number ='" + libraryID + "']");
            oldMember.ChildNodes.Item(0).InnerText = newMember.firstName;
            oldMember.ChildNodes.Item(1).InnerText = newMember.lastName;
            oldMember.ChildNodes.Item(2).InnerText = newMember.email;
            oldMember.ChildNodes.Item(3).InnerText = newMember.phone;
            oldMember.ChildNodes.Item(4).InnerText = newMember.libraryID;
            

            doc.Save(path);
        }

        
        }
    }

