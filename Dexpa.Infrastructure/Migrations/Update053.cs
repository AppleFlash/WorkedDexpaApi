namespace Dexpa.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update053 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "QiwiTransactionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "QiwiTransactionId");
        }
    }
}
