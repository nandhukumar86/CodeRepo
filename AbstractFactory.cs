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
public interface IMailer { }

public interface IMessenger { }


// 2. Create Abstract Factory
public interface IAbstractFactory
{
    IMessenger GetMessenger();
    IMailer GetMailer();
}


// 3. Create Products and Configurations and write logic inside
//    your configuration code goes here.
public class AWSMailer : IMailer { }
 
public class AzureMailer : IMailer { }
 
public class AWSMessenger : IMessenger { }
 
public class AzureMessenger : IMessenger { }



// 4. Create new Factories and more Factories to extend to other cloud platforms :)
public class AzureFactory : IAbstractFactory
{
    public IMessenger GetMessenger()
    {
        return new AzureMessenger();
    }
    public IMailer GetMailer()
    {
        return new AzureMailer();
    }
}

public class AWSFactory : IAbstractFactory
{
    public IMessenger GetMessenger()
    {
        return new AWSMessenger();
    }
    public IMailer GetMailer()
    {
        return new AWSMailer();
    }
}

// 5. Client Class
public class Client
{
    private IMailer _mailer;
    private IMessenger _messenger;

    public Client(IAbstractFactory factory)
    {
        _mailer = factory.GetMailer();
        _messenger = factory.GetMessenger();
    }
}