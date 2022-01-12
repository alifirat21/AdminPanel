namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messageContentUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MesssageContent", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MesssageContent", c => c.String());
        }
    }
}
