using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /******************************************************************
    Abstract Factory
    ----------------

    Requirement--

    Create Two products: Mailer and Messenger
    Create Two Factories: AWS and Azure
    Configurations: Azure should return objects of Azure SendGrid and Plivio
                    AWS should return objects of AWS.. services.

          AWS      |    Azure    |
    --------------------------------
     AWS Mailer    |  SendGrid   | Mailer 
    --------------------------------
     AWS Messenger |   Plivio    | Messenger
    ---------------------------------

    ******************************************************************/

    // 1. Create Products
    public interface IMailer
    {

    }

    public interface IMessenger
    {

    }

    // 2. Create Abstract Factory
    public interface IAbstractFactory
    {
        IMailer GetMailer();
        IMessenger GetMessenger();
    }

    // 3. Create Products and Configurations and write logic inside
    //    your configuration code goes here.
    public class AzureMailer : IMailer
    {

    }

    public class AzureMessenger : IMessenger
    {

    }

    public class AWSMailer: IMailer
    {

    }

    public class AWSMeseenger: IMessenger
    {

    }

    // 4. Create new Factories and more Factories to extend to other cloud platforms :)
    public class AzureFactory : IAbstractFactory
    {
        public IMailer GetMailer()
        {
            return new AzureMailer();
        }

        public IMessenger GetMessenger()
        {
            return new AzureMessenger();
        }
    }

    public class AWSFactory : IAbstractFactory
    {
        public IMailer GetMailer()
        {
            return new AWSMailer();
        }

        public IMessenger GetMessenger()
        {
            return new AWSMeseenger();
        }
    }

    // 5. Client Class
    public class Client
    {
        private IMailer _mailer;
        private IMessenger _messenger;

        public Client(IAbstractFactory abstractFactory)
        {
            _mailer = abstractFactory.GetMailer();
            _messenger = abstractFactory.GetMessenger();
        }
    }



}
