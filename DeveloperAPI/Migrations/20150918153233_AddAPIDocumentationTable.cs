using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace DeveloperAPI.Migrations
{
    public partial class AddAPIDocumentationTable : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "APIDocumentation",
                columns: table => new
                {
                    ID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    SampleImplementation = table.Column(type: "nvarchar(max)", nullable: true),
                    Url = table.Column(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIDocumentation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APIDocumentation_User_UserID",
                        columns: x => x.UserID,
                        referencedTable: "User",
                        referencedColumn: "UserID");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("APIDocumentation");
        }
    }
}
