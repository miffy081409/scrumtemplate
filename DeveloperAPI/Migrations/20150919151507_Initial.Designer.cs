using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using DeveloperAPI.Models;

namespace DeveloperAPI.Migrations
{
    [ContextType(typeof(ScrumDataContext))]
    partial class Initial
    {
        public override string Id
        {
            get { return "20150919151507_Initial"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("DeveloperAPI.Models.APIDocumentation", b =>
                {
                    b.Property<int>("ID")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<string>("Description");
                    
                    b.Property<string>("Name");
                    
                    b.Property<string>("SampleImplementation");
                    
                    b.Property<string>("Url");
                    
                    b.Property<string>("UserID");
                    
                    b.Key("ID");
                });
            
            builder.Entity("DeveloperAPI.Models.Attachment", b =>
                {
                    b.Property<string>("AttachmentID")
                        .GenerateValueOnAdd();
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<byte[]>("FileData");
                    
                    b.Property<string>("FileExt");
                    
                    b.Property<string>("Filename");
                    
                    b.Property<string>("TaskID");
                    
                    b.Property<string>("UserID");
                    
                    b.Key("AttachmentID");
                });
            
            builder.Entity("DeveloperAPI.Models.Comment", b =>
                {
                    b.Property<string>("CommentID")
                        .GenerateValueOnAdd();
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<string>("Message");
                    
                    b.Property<string>("TaskID");
                    
                    b.Property<string>("UserID");
                    
                    b.Key("CommentID");
                });
            
            builder.Entity("DeveloperAPI.Models.Project", b =>
                {
                    b.Property<string>("ProjectID")
                        .GenerateValueOnAdd();
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<string>("Description");
                    
                    b.Property<string>("Name");
                    
                    b.Property<int>("Status");
                    
                    b.Property<string>("UserID");
                    
                    b.Key("ProjectID");
                });
            
            builder.Entity("DeveloperAPI.Models.Sprint", b =>
                {
                    b.Property<string>("SprintID")
                        .GenerateValueOnAdd();
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<DateTime>("DateEnded");
                    
                    b.Property<DateTime>("DateStarted");
                    
                    b.Property<string>("ProjectID");
                    
                    b.Key("SprintID");
                });
            
            builder.Entity("DeveloperAPI.Models.Task", b =>
                {
                    b.Property<string>("TaskID")
                        .GenerateValueOnAdd();
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<DateTime>("DateEnded");
                    
                    b.Property<DateTime>("DateStarted");
                    
                    b.Property<string>("Description");
                    
                    b.Property<int>("Priority");
                    
                    b.Property<string>("SprintID");
                    
                    b.Property<string>("Title");
                    
                    b.Property<string>("UserID");
                    
                    b.Key("TaskID");
                });
            
            builder.Entity("DeveloperAPI.Models.User", b =>
                {
                    b.Property<string>("UserID")
                        .GenerateValueOnAdd();
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<bool>("IsScrumMaster");
                    
                    b.Property<string>("Password");
                    
                    b.Property<string>("Token");
                    
                    b.Property<string>("Username");
                    
                    b.Key("UserID");
                });
            
            builder.Entity("DeveloperAPI.Models.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<DateTime>("AddedOn");
                    
                    b.Property<DateTime>("Expiration");
                    
                    b.Property<string>("Token");
                    
                    b.Property<string>("UserID");
                    
                    b.Key("Id");
                });
            
            builder.Entity("DeveloperAPI.Models.APIDocumentation", b =>
                {
                    b.Reference("DeveloperAPI.Models.User")
                        .InverseCollection()
                        .ForeignKey("UserID");
                });
            
            builder.Entity("DeveloperAPI.Models.Attachment", b =>
                {
                    b.Reference("DeveloperAPI.Models.Task")
                        .InverseCollection()
                        .ForeignKey("TaskID");
                    
                    b.Reference("DeveloperAPI.Models.User")
                        .InverseCollection()
                        .ForeignKey("UserID");
                });
            
            builder.Entity("DeveloperAPI.Models.Comment", b =>
                {
                    b.Reference("DeveloperAPI.Models.Task")
                        .InverseCollection()
                        .ForeignKey("TaskID");
                    
                    b.Reference("DeveloperAPI.Models.User")
                        .InverseCollection()
                        .ForeignKey("UserID");
                });
            
            builder.Entity("DeveloperAPI.Models.Project", b =>
                {
                    b.Reference("DeveloperAPI.Models.User")
                        .InverseCollection()
                        .ForeignKey("UserID");
                });
            
            builder.Entity("DeveloperAPI.Models.Sprint", b =>
                {
                    b.Reference("DeveloperAPI.Models.Project")
                        .InverseCollection()
                        .ForeignKey("ProjectID");
                });
            
            builder.Entity("DeveloperAPI.Models.Task", b =>
                {
                    b.Reference("DeveloperAPI.Models.Sprint")
                        .InverseCollection()
                        .ForeignKey("SprintID");
                    
                    b.Reference("DeveloperAPI.Models.User")
                        .InverseCollection()
                        .ForeignKey("UserID");
                });
            
            builder.Entity("DeveloperAPI.Models.UserSession", b =>
                {
                    b.Reference("DeveloperAPI.Models.User")
                        .InverseCollection()
                        .ForeignKey("UserID");
                });
        }
    }
}
