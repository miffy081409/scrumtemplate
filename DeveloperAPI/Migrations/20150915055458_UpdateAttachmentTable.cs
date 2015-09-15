using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace DeveloperAPI.Migrations
{
    public partial class UpdateAttachmentTable : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Attachment_Task_TaskTaskID", table: "Attachment");
            migration.DropColumn(name: "TaskTaskID", table: "Attachment");
            migration.AddColumn(
                name: "TaskID",
                table: "Attachment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddColumn(
                name: "UserID",
                table: "Attachment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Attachment_Task_TaskID",
                table: "Attachment",
                column: "TaskID",
                referencedTable: "Task",
                referencedColumn: "TaskID");
            migration.AddForeignKey(
                name: "FK_Attachment_User_UserID",
                table: "Attachment",
                column: "UserID",
                referencedTable: "User",
                referencedColumn: "UserID");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Attachment_Task_TaskID", table: "Attachment");
            migration.DropForeignKey(name: "FK_Attachment_User_UserID", table: "Attachment");
            migration.DropColumn(name: "TaskID", table: "Attachment");
            migration.DropColumn(name: "UserID", table: "Attachment");
            migration.AddColumn(
                name: "TaskTaskID",
                table: "Attachment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Attachment_Task_TaskTaskID",
                table: "Attachment",
                column: "TaskTaskID",
                referencedTable: "Task",
                referencedColumn: "TaskID");
        }
    }
}
