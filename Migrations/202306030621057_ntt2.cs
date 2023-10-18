namespace FinalWindow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntt2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DayKeepContracts", "penaltyFee");
            DropColumn("dbo.LoanContracts", "penaltyFee");
            DropColumn("dbo.LongTermKeepContracts", "penaltyFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LongTermKeepContracts", "penaltyFee", c => c.Single());
            AddColumn("dbo.LoanContracts", "penaltyFee", c => c.Single());
            AddColumn("dbo.DayKeepContracts", "penaltyFee", c => c.Single());
        }
    }
}
