namespace DigitalLeap.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactsCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactInformations");
        }
    }
}
