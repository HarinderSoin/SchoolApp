namespace SchoolApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sampleparent : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Parents (Parent1Name, Parent1LastName, Parent2Name,Parent2LastName, " +
                "Address," + "City,StateID,  Zip,  HomePhone,  Mobile1,  Mobile2,  Email1,  Email2,  " +
                "Parent1WillVolunteer,  Parent1WillTeach,  Parent2WillVolunteer,  Parent2WillTeach) " +
                "values ('Parent1Name', 'Parent1LastName', 'Parent2Name','Parent2LastName', 'Address'," +
                "'City',1,  01545,  '2125551212',  '2125551212',  '2125551212',  'Email1@email.me',  " +
                "'Email2@email.me',  1,  1,  1,  1  )");
        }
        
        public override void Down()
        {
        }
    }
}
