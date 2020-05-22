using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public interface ITicket
    {
        void Accept(IVisitor visitor);
    }


    public class Ticket1 : ITicket
    {
 
        public void Accept(IVisitor visitor)
        {
            visitor.VisitTicket1(this);
        }


        public string Ticket1Method()
        {
            return "Ticket Kyiv-London";
        }
    }

    public class Ticket2 : ITicket
    {

        public void Accept(IVisitor visitor)
        {
            visitor.VisitTicket2(this);
        }

        public string Ticket2Method()
        {
            return "Ticket Kyiv-Lviv";
        }
    }


    public interface IVisitor
    {
        void VisitTicket1(Ticket1 element);

        void VisitTicket2(Ticket2 element);
    }


    class Visitor1 : IVisitor
    {
        public void VisitTicket1(Ticket1 element)
        {
            Console.WriteLine(element.Ticket1Method() + " was visited Visitor1");
        }

        public void VisitTicket2(Ticket2 element)
        {
            Console.WriteLine(element.Ticket2Method() + " was visited by Visitor1");
        }
    }

    class Visitor2 : IVisitor
    {
        public void VisitTicket1(Ticket1 element)
        {
            Console.WriteLine(element.Ticket1Method() + " was visited by Visitor2");
        }

        public void VisitTicket2(Ticket2 element)
        {
            Console.WriteLine(element.Ticket2Method() + " was visited by Visitor2");
        }
    }

    public class Client
    {

        public static void ClientCode(List<ITicket> components, IVisitor visitor)
        {
            foreach (var component in components)
            {
                component.Accept(visitor);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<ITicket> components = new List<ITicket>
            {
                new Ticket1(),
                new Ticket2()
            };

            var visitor1 = new Visitor1();
            Client.ClientCode(components, visitor1);

            Console.WriteLine();

            var visitor2 = new Visitor2();
            Client.ClientCode(components, visitor2);
        }
    }
}