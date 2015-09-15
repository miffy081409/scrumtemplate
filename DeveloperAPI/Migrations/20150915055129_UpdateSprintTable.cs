using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace DeveloperAPI.Migrations
{
    public partial class UpdateSprintTable : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Task_Sprint_SprintSprintID", table: "Task");
            migration.DropColumn(name: "SprintSprintID", table: "Task");
            migration.AddColumn(
                name: "SprintID",
                table: "Task",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Task_Sprint_SprintID",
                table: "Task",
                column: "SprintID",
                referencedTable: "Sprint",
                referencedColumn: "SprintID");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Task_Sprint_SprintID", table: "Task");
            migration.DropColumn(name: "SprintID", table: "Task");
            migration.AddColumn(
                name: "SprintSprintID",
                table: "Task",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Task_Sprint_SprintSprintID",
                table: "Task",
                column: "SprintSprintID",
                referencedTable: "Sprint",
                referencedColumn: "SprintID");
        }
    }
}
