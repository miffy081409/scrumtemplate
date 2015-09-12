using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace DeveloperAPI.Migrations
{
    public partial class Initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    IsScrumMaster = table.Column(type: "bit", nullable: false),
                    Password = table.Column(type: "nvarchar(max)", nullable: true),
                    Token = table.Column(type: "nvarchar(max)", nullable: true),
                    Username = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
            migration.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true),
                    Status = table.Column(type: "int", nullable: false),
                    UserID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Project_User_UserID",
                        columns: x => x.UserID,
                        referencedTable: "User",
                        referencedColumn: "UserID");
                });
            migration.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    SprintID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    DateEnded = table.Column(type: "datetime2", nullable: false),
                    DateStarted = table.Column(type: "datetime2", nullable: false),
                    ProjectID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.SprintID);
                    table.ForeignKey(
                        name: "FK_Sprint_Project_ProjectID",
                        columns: x => x.ProjectID,
                        referencedTable: "Project",
                        referencedColumn: "ProjectID");
                });
            migration.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    DateEnded = table.Column(type: "datetime2", nullable: false),
                    DateStarted = table.Column(type: "datetime2", nullable: false),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column(type: "int", nullable: false),
                    SprintSprintID = table.Column(type: "nvarchar(450)", nullable: true),
                    Title = table.Column(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Sprint_SprintSprintID",
                        columns: x => x.SprintSprintID,
                        referencedTable: "Sprint",
                        referencedColumn: "SprintID");
                    table.ForeignKey(
                        name: "FK_Task_User_UserID",
                        columns: x => x.UserID,
                        referencedTable: "User",
                        referencedColumn: "UserID");
                });
            migration.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    AttachmentID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    FileData = table.Column(type: "varbinary(max)", nullable: true),
                    FileExt = table.Column(type: "nvarchar(max)", nullable: true),
                    Filename = table.Column(type: "nvarchar(max)", nullable: true),
                    TaskTaskID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_Attachment_Task_TaskTaskID",
                        columns: x => x.TaskTaskID,
                        referencedTable: "Task",
                        referencedColumn: "TaskID");
                });
            migration.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column(type: "datetime2", nullable: false),
                    Message = table.Column(type: "nvarchar(max)", nullable: true),
                    TaskTaskID = table.Column(type: "nvarchar(450)", nullable: true),
                    UserUserID = table.Column(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comment_Task_TaskTaskID",
                        columns: x => x.TaskTaskID,
                        referencedTable: "Task",
                        referencedColumn: "TaskID");
                    table.ForeignKey(
                        name: "FK_Comment_User_UserUserID",
                        columns: x => x.UserUserID,
                        referencedTable: "User",
                        referencedColumn: "UserID");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Attachment");
            migration.DropTable("Comment");
            migration.DropTable("Project");
            migration.DropTable("Sprint");
            migration.DropTable("Task");
            migration.DropTable("User");
        }
    }
}
