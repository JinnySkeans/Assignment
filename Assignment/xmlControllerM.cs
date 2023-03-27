using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment
{
    public class XmlControllerM
    {
        string path = "Members.xml";
        public void AddMember(Member newMember)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode ROOT = doc.SelectSingleNode("/members");
            XmlNode Member = doc.CreateElement("member");
            XmlNode FirstName = doc.CreateElement("first_name");
            XmlNode SecondName = doc.CreateElement("second_name");
            XmlNode FirstLineAddress = doc.CreateElement("address_line_1");
            XmlNode SecondLineAddress = doc.CreateElement("address_line_2");
            XmlNode City = doc.CreateElement("city");
            XmlNode County = doc.CreateElement("county");
            XmlNode Postcode = doc.CreateElement("postcode");
            XmlNode LibraryID = doc.CreateElement("library_card_number");

            FirstName.InnerText = newMember.firstName;
            SecondName.InnerText = newMember.lastName;
            FirstLineAddress.InnerText = newMember.firstLineAddress;
            SecondLineAddress.InnerText = newMember.secondLineAddress;
            City.InnerText = newMember.city;
            County.InnerText = newMember.county;
            Postcode.InnerText = newMember.postcode;
            LibraryID.InnerText = newMember.libraryID;

            Member.AppendChild(FirstName);
            Member.AppendChild(SecondName);
            Member.AppendChild(FirstLineAddress);
            Member.AppendChild(SecondLineAddress);
            Member.AppendChild(City);
            Member.AppendChild(County);
            Member.AppendChild(Postcode);
            Member.AppendChild(LibraryID);

            ROOT.AppendChild(Member);
            doc.Save(path);
        }

        public bool deleteMember(string libraryID)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode node = doc.SelectSingleNode("//member[libraryID = '" + libraryID + "']");
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
            XmlNode oldMember = doc!.SelectSingleNode("//member[libraryID='" + libraryID + "']");
            oldMember.ChildNodes.Item(0).InnerText = newMember.firstName;
            oldMember.ChildNodes.Item(1).InnerText = newMember.lastName;
            oldMember.ChildNodes.Item(2).InnerText = newMember.firstLineAddress;
            oldMember.ChildNodes.Item(3).InnerText = newMember.secondLineAddress;
            oldMember.ChildNodes.Item(4).InnerText = newMember.city;
            oldMember.ChildNodes.Item(5).InnerText = newMember.county;
            oldMember.ChildNodes.Item(6).InnerText = newMember.postcode;

            doc.Save(path);
        }
    }
}
