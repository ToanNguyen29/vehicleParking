namespace FinalWindow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        fixID = c.Int(),
                        keepID = c.Int(),
                        dateWork = c.DateTime(nullable: false),
                        hourWork = c.Single(),
                        baseSalary = c.Single(),
                        bonusSalary = c.Single(),
                        penaltySalary = c.Single(),
                        totalSalary = c.Single(),
                        FixWorker_ID = c.Int(),
                        KeepWorker_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FixWorkers", t => t.FixWorker_ID)
                .ForeignKey("dbo.KeepWorkers", t => t.KeepWorker_ID)
                .Index(t => t.FixWorker_ID)
                .Index(t => t.KeepWorker_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        phone = c.String(maxLength: 20),
                        email = c.String(),
                        birthday = c.DateTime(),
                        dateCreate = c.DateTime(),
                        active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BillFixes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateCreate = c.DateTime(),
                        description = c.String(),
                        vehicle = c.String(),
                        fixWorkerID = c.Int(),
                        customerID = c.Int(),
                        totalBill = c.Single(),
                        facilityID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.customerID)
                .ForeignKey("dbo.Facilities", t => t.facilityID)
                .ForeignKey("dbo.FixWorkers", t => t.fixWorkerID)
                .Index(t => t.fixWorkerID)
                .Index(t => t.customerID)
                .Index(t => t.facilityID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        branch = c.String(),
                        picture = c.Binary(),
                        status = c.String(),
                        numberVehicle = c.String(),
                        licensePlates = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Facilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        address = c.String(maxLength: 50),
                        quatityFix = c.Int(),
                        quantityKeep = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        fixID = c.Int(),
                        keepID = c.Int(),
                        month = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        totalSalary = c.Single(),
                        FixWorker_ID = c.Int(),
                        KeepWorker_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FixWorkers", t => t.FixWorker_ID)
                .ForeignKey("dbo.KeepWorkers", t => t.KeepWorker_ID)
                .Index(t => t.FixWorker_ID)
                .Index(t => t.KeepWorker_ID);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        startTime = c.Time(nullable: false, precision: 7),
                        endTime = c.Time(nullable: false, precision: 7),
                        quantityKeep = c.Int(),
                        quantityFix = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Revenues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        facilityID = c.Int(),
                        month = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        fixFee = c.Single(nullable: false),
                        KeepFee = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Facilities", t => t.facilityID)
                .Index(t => t.facilityID);
            
            CreateTable(
                "dbo.BaseSalaries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        typeWorker = c.String(),
                        baseSalary = c.Single(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FeeKeeps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        typeVehicle = c.String(),
                        dayPrice = c.Single(),
                        weekPrice = c.Single(),
                        monthPrice = c.Single(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        nameContract = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        phone = c.String(maxLength: 20),
                        email = c.String(),
                        birthday = c.DateTime(),
                        dateCreate = c.DateTime(),
                        active = c.Boolean(nullable: false),
                        cardID = c.String(),
                        address = c.String(maxLength: 50),
                        picture = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        phone = c.String(maxLength: 20),
                        email = c.String(),
                        birthday = c.DateTime(),
                        dateCreate = c.DateTime(),
                        active = c.Boolean(nullable: false),
                        cardID = c.String(),
                        address = c.String(),
                        picture = c.Binary(),
                        facilityID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Facilities", t => t.facilityID)
                .Index(t => t.facilityID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        phone = c.String(maxLength: 20),
                        email = c.String(),
                        birthday = c.DateTime(),
                        dateCreate = c.DateTime(),
                        active = c.Boolean(nullable: false),
                        address = c.String(),
                        picture = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FixWorkers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        phone = c.String(maxLength: 20),
                        email = c.String(),
                        birthday = c.DateTime(),
                        dateCreate = c.DateTime(),
                        active = c.Boolean(nullable: false),
                        cardID = c.String(),
                        address = c.String(),
                        picture = c.Binary(),
                        shiftID = c.Int(),
                        facilityID = c.Int(),
                        coefficients = c.Single(),
                        baseSalary = c.Single(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Shifts", t => t.shiftID)
                .ForeignKey("dbo.Facilities", t => t.facilityID)
                .Index(t => t.shiftID)
                .Index(t => t.facilityID);
            
            CreateTable(
                "dbo.KeepWorkers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        gender = c.String(),
                        phone = c.String(maxLength: 20),
                        email = c.String(),
                        birthday = c.DateTime(),
                        dateCreate = c.DateTime(),
                        active = c.Boolean(nullable: false),
                        cardID = c.String(),
                        address = c.String(),
                        picture = c.Binary(),
                        shiftID = c.Int(),
                        facilityID = c.Int(),
                        coefficients = c.Single(),
                        baseSalary = c.Single(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Shifts", t => t.shiftID)
                .ForeignKey("dbo.Facilities", t => t.facilityID)
                .Index(t => t.shiftID)
                .Index(t => t.facilityID);
            
            CreateTable(
                "dbo.DayKeepContracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        key = c.String(),
                        rule = c.String(),
                        dateStartActual = c.DateTime(),
                        dateEnd = c.DateTime(),
                        dateCreate = c.DateTime(),
                        dateEndActual = c.DateTime(),
                        fee = c.Single(),
                        penaltyFee = c.Single(),
                        customerID = c.Int(),
                        carID = c.Int(),
                        motorID = c.Int(),
                        truckID = c.Int(),
                        facilityId = c.Int(),
                        status = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.customerID)
                .ForeignKey("dbo.Cars", t => t.carID)
                .ForeignKey("dbo.Motors", t => t.motorID)
                .ForeignKey("dbo.Trucks", t => t.truckID)
                .ForeignKey("dbo.Facilities", t => t.facilityId)
                .Index(t => t.customerID)
                .Index(t => t.carID)
                .Index(t => t.motorID)
                .Index(t => t.truckID)
                .Index(t => t.facilityId);
            
            CreateTable(
                "dbo.LoanContracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        key = c.String(),
                        rule = c.String(),
                        dateStartActual = c.DateTime(),
                        dateEnd = c.DateTime(),
                        dateCreate = c.DateTime(),
                        dateEndActual = c.DateTime(),
                        fee = c.Single(),
                        penaltyFee = c.Single(),
                        customerID = c.Int(),
                        carID = c.Int(),
                        motorID = c.Int(),
                        truckID = c.Int(),
                        facilityId = c.Int(),
                        status = c.String(maxLength: 50),
                        condition = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.customerID)
                .ForeignKey("dbo.Cars", t => t.carID)
                .ForeignKey("dbo.Motors", t => t.motorID)
                .ForeignKey("dbo.Trucks", t => t.truckID)
                .ForeignKey("dbo.Facilities", t => t.facilityId)
                .Index(t => t.customerID)
                .Index(t => t.carID)
                .Index(t => t.motorID)
                .Index(t => t.truckID)
                .Index(t => t.facilityId);
            
            CreateTable(
                "dbo.LongTermKeepContracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        key = c.String(),
                        rule = c.String(),
                        dateStartActual = c.DateTime(),
                        dateEnd = c.DateTime(),
                        dateCreate = c.DateTime(),
                        dateEndActual = c.DateTime(),
                        fee = c.Single(),
                        penaltyFee = c.Single(),
                        customerID = c.Int(),
                        carID = c.Int(),
                        motorID = c.Int(),
                        truckID = c.Int(),
                        facilityId = c.Int(),
                        status = c.String(maxLength: 50),
                        is_Loan = c.Boolean(nullable: false),
                        period = c.Single(nullable: false),
                        typeContract = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.customerID)
                .ForeignKey("dbo.Cars", t => t.carID)
                .ForeignKey("dbo.Motors", t => t.motorID)
                .ForeignKey("dbo.Trucks", t => t.truckID)
                .ForeignKey("dbo.Facilities", t => t.facilityId)
                .Index(t => t.customerID)
                .Index(t => t.carID)
                .Index(t => t.motorID)
                .Index(t => t.truckID)
                .Index(t => t.facilityId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        branch = c.String(),
                        picture = c.Binary(),
                        status = c.String(),
                        numberVehicle = c.String(),
                        licensePlates = c.String(maxLength: 20),
                        seat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Motors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        branch = c.String(),
                        picture = c.Binary(),
                        status = c.String(),
                        numberVehicle = c.String(),
                        licensePlates = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trucks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        branch = c.String(),
                        picture = c.Binary(),
                        status = c.String(),
                        numberVehicle = c.String(),
                        licensePlates = c.String(maxLength: 20),
                        tonnage = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LongTermKeepContracts", "facilityId", "dbo.Facilities");
            DropForeignKey("dbo.LongTermKeepContracts", "truckID", "dbo.Trucks");
            DropForeignKey("dbo.LongTermKeepContracts", "motorID", "dbo.Motors");
            DropForeignKey("dbo.LongTermKeepContracts", "carID", "dbo.Cars");
            DropForeignKey("dbo.LongTermKeepContracts", "customerID", "dbo.Customers");
            DropForeignKey("dbo.LoanContracts", "facilityId", "dbo.Facilities");
            DropForeignKey("dbo.LoanContracts", "truckID", "dbo.Trucks");
            DropForeignKey("dbo.LoanContracts", "motorID", "dbo.Motors");
            DropForeignKey("dbo.LoanContracts", "carID", "dbo.Cars");
            DropForeignKey("dbo.LoanContracts", "customerID", "dbo.Customers");
            DropForeignKey("dbo.DayKeepContracts", "facilityId", "dbo.Facilities");
            DropForeignKey("dbo.DayKeepContracts", "truckID", "dbo.Trucks");
            DropForeignKey("dbo.DayKeepContracts", "motorID", "dbo.Motors");
            DropForeignKey("dbo.DayKeepContracts", "carID", "dbo.Cars");
            DropForeignKey("dbo.DayKeepContracts", "customerID", "dbo.Customers");
            DropForeignKey("dbo.KeepWorkers", "facilityID", "dbo.Facilities");
            DropForeignKey("dbo.KeepWorkers", "shiftID", "dbo.Shifts");
            DropForeignKey("dbo.FixWorkers", "facilityID", "dbo.Facilities");
            DropForeignKey("dbo.FixWorkers", "shiftID", "dbo.Shifts");
            DropForeignKey("dbo.Managers", "facilityID", "dbo.Facilities");
            DropForeignKey("dbo.BillFixes", "fixWorkerID", "dbo.FixWorkers");
            DropForeignKey("dbo.Revenues", "facilityID", "dbo.Facilities");
            DropForeignKey("dbo.Salaries", "KeepWorker_ID", "dbo.KeepWorkers");
            DropForeignKey("dbo.Salaries", "FixWorker_ID", "dbo.FixWorkers");
            DropForeignKey("dbo.Attendances", "KeepWorker_ID", "dbo.KeepWorkers");
            DropForeignKey("dbo.BillFixes", "facilityID", "dbo.Facilities");
            DropForeignKey("dbo.BillFixes", "customerID", "dbo.Customers");
            DropForeignKey("dbo.Attendances", "FixWorker_ID", "dbo.FixWorkers");
            DropIndex("dbo.LongTermKeepContracts", new[] { "facilityId" });
            DropIndex("dbo.LongTermKeepContracts", new[] { "truckID" });
            DropIndex("dbo.LongTermKeepContracts", new[] { "motorID" });
            DropIndex("dbo.LongTermKeepContracts", new[] { "carID" });
            DropIndex("dbo.LongTermKeepContracts", new[] { "customerID" });
            DropIndex("dbo.LoanContracts", new[] { "facilityId" });
            DropIndex("dbo.LoanContracts", new[] { "truckID" });
            DropIndex("dbo.LoanContracts", new[] { "motorID" });
            DropIndex("dbo.LoanContracts", new[] { "carID" });
            DropIndex("dbo.LoanContracts", new[] { "customerID" });
            DropIndex("dbo.DayKeepContracts", new[] { "facilityId" });
            DropIndex("dbo.DayKeepContracts", new[] { "truckID" });
            DropIndex("dbo.DayKeepContracts", new[] { "motorID" });
            DropIndex("dbo.DayKeepContracts", new[] { "carID" });
            DropIndex("dbo.DayKeepContracts", new[] { "customerID" });
            DropIndex("dbo.KeepWorkers", new[] { "facilityID" });
            DropIndex("dbo.KeepWorkers", new[] { "shiftID" });
            DropIndex("dbo.FixWorkers", new[] { "facilityID" });
            DropIndex("dbo.FixWorkers", new[] { "shiftID" });
            DropIndex("dbo.Managers", new[] { "facilityID" });
            DropIndex("dbo.Revenues", new[] { "facilityID" });
            DropIndex("dbo.Salaries", new[] { "KeepWorker_ID" });
            DropIndex("dbo.Salaries", new[] { "FixWorker_ID" });
            DropIndex("dbo.BillFixes", new[] { "facilityID" });
            DropIndex("dbo.BillFixes", new[] { "customerID" });
            DropIndex("dbo.BillFixes", new[] { "fixWorkerID" });
            DropIndex("dbo.Attendances", new[] { "KeepWorker_ID" });
            DropIndex("dbo.Attendances", new[] { "FixWorker_ID" });
            DropTable("dbo.Trucks");
            DropTable("dbo.Motors");
            DropTable("dbo.Cars");
            DropTable("dbo.LongTermKeepContracts");
            DropTable("dbo.LoanContracts");
            DropTable("dbo.DayKeepContracts");
            DropTable("dbo.KeepWorkers");
            DropTable("dbo.FixWorkers");
            DropTable("dbo.Customers");
            DropTable("dbo.Managers");
            DropTable("dbo.Directors");
            DropTable("dbo.Rules");
            DropTable("dbo.FeeKeeps");
            DropTable("dbo.BaseSalaries");
            DropTable("dbo.Revenues");
            DropTable("dbo.Shifts");
            DropTable("dbo.Salaries");
            DropTable("dbo.Facilities");
            DropTable("dbo.Vehicles");
            DropTable("dbo.BillFixes");
            DropTable("dbo.Users");
            DropTable("dbo.Attendances");
        }
    }
}
