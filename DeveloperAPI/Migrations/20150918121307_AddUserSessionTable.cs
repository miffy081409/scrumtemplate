using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace DeveloperAPI.Migrations
{
    public partial class AddUserSessionTable : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    Expiration = table.Column(type: "datetime2", nullable: false),
                    Token = table.Column(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSession_User_UserID",
                        columns: x => x.UserID,
                        referencedTable: "User",
                        referencedColumn: "UserID");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("UserSession");
        }
    }
}
