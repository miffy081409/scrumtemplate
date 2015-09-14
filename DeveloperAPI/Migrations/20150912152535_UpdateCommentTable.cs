using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace DeveloperAPI.Migrations
{
    public partial class UpdateCommentTable : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Comment_Task_TaskTaskID", table: "Comment");
            migration.DropForeignKey(name: "FK_Comment_User_UserUserID", table: "Comment");
            migration.DropColumn(name: "TaskTaskID", table: "Comment");
            migration.DropColumn(name: "UserUserID", table: "Comment");
            migration.AddColumn(
                name: "TaskID",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddColumn(
                name: "UserID",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Comment_Task_TaskID",
                table: "Comment",
                column: "TaskID",
                referencedTable: "Task",
                referencedColumn: "TaskID");
            migration.AddForeignKey(
                name: "FK_Comment_User_UserID",
                table: "Comment",
                column: "UserID",
                referencedTable: "User",
                referencedColumn: "UserID");
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropForeignKey(name: "FK_Comment_Task_TaskID", table: "Comment");
            migration.DropForeignKey(name: "FK_Comment_User_UserID", table: "Comment");
            migration.DropColumn(name: "TaskID", table: "Comment");
            migration.DropColumn(name: "UserID", table: "Comment");
            migration.AddColumn(
                name: "TaskTaskID",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddColumn(
                name: "UserUserID",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);
            migration.AddForeignKey(
                name: "FK_Comment_Task_TaskTaskID",
                table: "Comment",
                column: "TaskTaskID",
                referencedTable: "Task",
                referencedColumn: "TaskID");
            migration.AddForeignKey(
                name: "FK_Comment_User_UserUserID",
                table: "Comment",
                column: "UserUserID",
                referencedTable: "User",
                referencedColumn: "UserID");
        }
    }
}
