namespace FinalWindow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntt1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendances", name: "FixWorker_ID", newName: "fixWorkerID");
            RenameColumn(table: "dbo.Attendances", name: "KeepWorker_ID", newName: "keepWorkerID");
            RenameColumn(table: "dbo.Salaries", name: "FixWorker_ID", newName: "fixWorkerID");
            RenameColumn(table: "dbo.Salaries", name: "KeepWorker_ID", newName: "keepWorkerID");
            RenameIndex(table: "dbo.Attendances", name: "IX_FixWorker_ID", newName: "IX_fixWorkerID");
            RenameIndex(table: "dbo.Attendances", name: "IX_KeepWorker_ID", newName: "IX_keepWorkerID");
            RenameIndex(table: "dbo.Salaries", name: "IX_FixWorker_ID", newName: "IX_fixWorkerID");
            RenameIndex(table: "dbo.Salaries", name: "IX_KeepWorker_ID", newName: "IX_keepWorkerID");
            DropColumn("dbo.Attendances", "fixID");
            DropColumn("dbo.Attendances", "keepID");
            DropColumn("dbo.Salaries", "fixID");
            DropColumn("dbo.Salaries", "keepID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Salaries", "keepID", c => c.Int());
            AddColumn("dbo.Salaries", "fixID", c => c.Int());
            AddColumn("dbo.Attendances", "keepID", c => c.Int());
            AddColumn("dbo.Attendances", "fixID", c => c.Int());
            RenameIndex(table: "dbo.Salaries", name: "IX_keepWorkerID", newName: "IX_KeepWorker_ID");
            RenameIndex(table: "dbo.Salaries", name: "IX_fixWorkerID", newName: "IX_FixWorker_ID");
            RenameIndex(table: "dbo.Attendances", name: "IX_keepWorkerID", newName: "IX_KeepWorker_ID");
            RenameIndex(table: "dbo.Attendances", name: "IX_fixWorkerID", newName: "IX_FixWorker_ID");
            RenameColumn(table: "dbo.Salaries", name: "keepWorkerID", newName: "KeepWorker_ID");
            RenameColumn(table: "dbo.Salaries", name: "fixWorkerID", newName: "FixWorker_ID");
            RenameColumn(table: "dbo.Attendances", name: "keepWorkerID", newName: "KeepWorker_ID");
            RenameColumn(table: "dbo.Attendances", name: "fixWorkerID", newName: "FixWorker_ID");
        }
    }
}
